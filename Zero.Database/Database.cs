using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace Zero.Data
{
    /// <summary>
    /// 数据库操作
    /// </summary>
    public class Database
    {
        Database()
        {
        }

        private static Database instance = new Database();

        public static Database Instance()
        {
            return instance;
        }

        #region Member Fields
        public string _connectionString;
        public string _providerName;
        DbProviderFactory _factory;
        IDbConnection _connection;
        IDbTransaction _transaction;
        IDataAdapter _adapter;
        IDataReader _reader;
        #endregion

        #region Constructors

        //public Database(string connectionString)
        //{
        //   
        //}

        public Database(string connectionString, string providerName)
        {
            _connectionString = connectionString;
            _providerName = providerName;

            if (string.IsNullOrEmpty(providerName))
            {
                _factory = DbProviderFactories.GetFactory(providerName);
            }
        }

        #endregion

        #region Management: Connection

        public void OpenConnection()
        {
            _connection = _factory.CreateConnection();
            _connection.ConnectionString = _connectionString;

            if (_connection.State == ConnectionState.Broken)
                _connection.Close();

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open || _connection.State == ConnectionState.Broken)
                _connection.Close();
        }

        #endregion

        #region Management: Command

        public IDbCommand CreateCommand(IDbConnection connection, string sql, params object[] args)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Transaction = _transaction;
            //command.CommandType=
            //foreach (object item in args)
            //{
            //    AddParam(command, item);
            //}
            return command;
        }

        public IDbCommand CreateCommand(IDbConnection connection)
        {
            IDbCommand command = connection.CreateCommand();
            command.Transaction = _transaction;
            //command.CommandType=
            return command;
        }

        #endregion

        #region Management: Param

        public void AddParameter(IDbCommand command, string name, object value)
        {
            var param = command.CreateParameter();

            param.ParameterName = name;

            var t = value.GetType();

            if (t.IsEnum)
            {
                param.Value = (int)value;
            }
            else
            {
                param.Value = value;
            }

            command.Parameters.Add(param);
        }

        #endregion

        #region Management: Transaction
        #endregion

        #region Operation: Execute

        public int Execute(string sql, params object[] args)
        {
            try
            {
                OpenConnection();

                using (IDbCommand command = CreateCommand(_connection,sql, args))
                {
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        #endregion

        #region Operation: ExecuteScalar

        public T ExecuteScalar<T>(string sql, params object[] args)
        {
            try
            {
                OpenConnection();

                using (IDbCommand command = CreateCommand(_connection,sql, args))
                {
                    object val = command.ExecuteScalar();
                    return (T)Convert.ChangeType(val, typeof(T));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        #endregion

        #region Operation: Insert

        public int Insert(object obj)
        {
            try
            {
                OpenConnection();

                using (IDbCommand command = CreateCommand(_connection))
                {
                    TableInfo tableInfo = EntityHelper.GetEntityInfo(obj);


                    foreach (var column in tableInfo.ColumnList)
                    {
                        if (!string.IsNullOrEmpty(tableInfo.PrimaryKey) && tableInfo.PrimaryKey.Contains(column.Key)) continue;
                        if (column.Value.IsIgnoreInsert) continue;
                        if (column.Value.IsPrimaryKey) continue;

                        var name = column.Key;
                        var value = column.Value.PropertyInfo.GetValue(column.Key);
                        AddParameter(command, name, value);
                    }

                    string sql = Sql.GetInsertSql(tableInfo.Name, tableInfo.ColumnList.Keys.ToArray());

                    command.CommandText = sql;

                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        #endregion

        #region Operation: Update

        public int Update(object obj, IEnumerable<string> columns)
        {
            try
            {
                OpenConnection();

                using (IDbCommand command = CreateCommand(_connection))
                {
                    TableInfo tableInfo = EntityHelper.GetEntityInfo(obj);
                    StringBuilder felds = new StringBuilder();
                    StringBuilder where = new StringBuilder();

                    if (columns == null)
                    {
                        foreach (var column in tableInfo.ColumnList)
                        {
                            if (column.Value.IsIgnoreUpdate) continue;

                            var name = column.Key;
                            var value = column.Value.PropertyInfo.GetValue(column.Key);
                            AddParameter(command, name, value);

                            if (string.IsNullOrEmpty(tableInfo.PrimaryKey) || !tableInfo.PrimaryKey.Contains(column.Key))
                            {
                                felds.AppendFormat(",{0}=@{0}", name);
                            }
                            else
                            {
                                where.AppendFormat("{0}=@{0}", name);
                            }
                        }
                    }
                    else
                    {
                        foreach (var columnName in columns)
                        {
                            var column = tableInfo.ColumnList[columnName];

                            if (column.IsIgnoreUpdate) continue;

                            felds.AppendFormat(",{0}=@{0}", columnName);

                            AddParameter(command, columnName, column.PropertyInfo.GetValue(columnName));
                        }

                        if (tableInfo.PrimaryKey != null)
                        {
                            var primaryKeyValue = tableInfo.ColumnList[tableInfo.PrimaryKey].PropertyInfo.GetValue(tableInfo.PrimaryKey);

                            where.AppendFormat("{0}=@{0}", tableInfo.PrimaryKey);

                            AddParameter(command, tableInfo.PrimaryKey, primaryKeyValue);
                        }
                    }

                    if (felds.Length > 0) felds.Remove(0, 1);

                    string sql = Sql.GetUpdateSql(tableInfo.Name, felds.ToString(), where.ToString());

                    command.CommandText = sql;

                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public int Update(object obj)
        {
            return Update(obj, null);
        }

        public int Update<T>(string sql, params object[] args)
        {
            TableInfo tableInfo = EntityHelper.GetEntityInfo(typeof(T));
            sql = string.Format("update {0} {1}", tableInfo.Name, sql);
            return Execute(sql, args);
        }

        #endregion

        #region Operation: Delete

        public int Delete(object obj)
        {
            TableInfo tableInfo = EntityHelper.GetEntityInfo(obj);

            var column = tableInfo.ColumnList[tableInfo.PrimaryKey].PropertyInfo;

            string sql = string.Format("delete {0} where {1}=@0", tableInfo.Name);
            return Execute(sql, column.GetValue(tableInfo.PrimaryKey));
        }

        public int Delete<T>(string sql, params object[] args)
        {
            TableInfo tableInfo = EntityHelper.GetEntityInfo(typeof(T));
            sql = string.Format("delete {0} {1}", tableInfo.Name, sql);
            return Execute(sql, args);
        }

        #endregion

        #region Operation: Exist

        public int Exist<T>(object primaryKey)
        {
            return 0;
        }

        #endregion

        #region Operation: Select

        public T Single<T>(string primaryKey)
        {
            throw new  NotImplementedException();
        }

        public T Single<T>(string sql, params object[] args)
        {
            try
            {
                OpenConnection();

                Type type = typeof(T);

                TableInfo tableInfo = EntityHelper.GetEntityInfo(type);

                using (IDbCommand command = CreateCommand(_connection))
                {
                    command.CommandText = sql;

                    IDataReader dr = command.ExecuteReader();

                    T info = default(T);

                    if(dr.Read())
                    {
                        info = Activator.CreateInstance<T>(); ;

                        foreach (var column in tableInfo.ColumnList)
                        {
                            if (column.Value.IsIgnoreSelect) continue;

                            column.Value.PropertyInfo.SetValue(info, dr[column.Key]);
                        }
                    }
                    dr.Close();

                    return info;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<T> Select<T>(string sql, params object[] args)
        {
            try
            {
                OpenConnection();

                Type type = typeof(T);

                TableInfo tableInfo = EntityHelper.GetEntityInfo(type);

                using (IDbCommand command = CreateCommand(_connection))
                {
                    command.CommandText = sql;

                    IDataReader dr = command.ExecuteReader();

                    T info = default(T);

                    List<T> list = new List<T>();

                    if (dr.Read())
                    {
                        info = Activator.CreateInstance<T>(); ;

                        foreach (var column in tableInfo.ColumnList)
                        {
                            if (column.Value.IsIgnoreSelect) continue;

                            column.Value.PropertyInfo.SetValue(info, dr[column.Key]);
                        }

                        list.Add(info);
                    }
                    dr.Close();

                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

            throw new NotImplementedException();
        }

        public List<T> Select<T>(long pageIndex, long pageSize, string sql, params object[] args)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Operation: Page

        public Page<T> Page<T>(long pageIndex, long pageSize, string sql, params object[] args)
        {
            throw new NotImplementedException();
        }

        public Page<T> Page<T>(long pageIndex, long pageSize)
        {
            throw new NotImplementedException();
        }

        #endregion
    }


    /// <summary>
    /// 分页
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Page<T>
    {
        public long PageIndex { get; set; }
        public long TotalPages { get; set; }
        public long TotalItems { get; set; }
        public long PageSize { get; set; }
        public List<T> Items { get; set; }
        public object Context { get; set; }
    }



    //public interface ISql
    //{
    //    string InsertSql();
    //}

    ///// <summary>
    ///// mssql构建语句
    ///// </summary>
    //public class SqlServer 
    //{
    //    public static string InsertSql(string tableName, object[] args)
    //    {
    //        return "insert into [TableName](Name,Sex) values(@Name,@Sex)";
    //    }

    //    public static string InsertSql(object obj)
    //    {
    //        return "insert into [TableName](Name,Sex) values(@Name,@Sex)";
    //    }

    //    public string UpdateSql()
    //    {
    //        return "update set Name=@Name,Sex=@Sex from [TableName] where ID=@ID";
    //    }

    //    public string SelectSql()
    //    {
    //        return "select * from [TableName] where ID=@ID and sex='难' order by ID des  group by ID";
    //    }

    //    public void Select()
    //    {
    //    }

    //    public void From()
    //    {
    //    }

    //    public void Where()
    //    {
    //    }

    //    public void GroupBy()
    //    {
    //    }

    //    public void OrderBy()
    //    {
    //    }
    //}

    //public enum DBType
    //{
    //    SqlServer,
    //    SqlServerCE,
    //    MySql,
    //    PostgreSQL,
    //    Oracle,
    //    SQLite
    //}

    //public enum SearchComponent
    //{
    //    /// <summary>
    //    /// 对应数据库中的 "="
    //    /// </summary>
    //    Equals,

    //    /// <summary>
    //    /// 对应数据库中的 "!="
    //    /// </summary>
    //    UnEquals,

    //    /// <summary>
    //    /// 对应数据库中的 ">"
    //    /// </summary>
    //    Greater,

    //    /// <summary>
    //    /// /// 对应数据库中的 ">="
    //    /// </summary>
    //    GreaterOrEquals,

    //    /// <summary>
    //    /// 对应数据库中的 "<"
    //    /// </summary>
    //    Less,

    //    /// <summary>
    //    /// 对应数据库中的 "<="
    //    /// </summary>
    //    LessOrEquals,

    //    /// <summary>
    //    /// 对应数据库中的 "like"
    //    /// </summary>
    //    Like,

    //    /// <summary>
    //    /// 对应数据库中的 "in"
    //    /// </summary>
    //    In,

    //    /// <summary>
    //    /// 对应数据库中的 "between and"
    //    /// </summary>
    //    Between,

    //    /// <summary>
    //    /// 对应数据库中的 "order by asc"
    //    /// </summary>
    //    OrderAsc,

    //    /// <summary>
    //    /// 对应数据库中的 "order by desc"
    //    /// </summary>
    //    OrderDesc,
    //    /// <summary>
    //    /// 对应数据库中的 "group by"
    //    /// </summary>
    //    GroupBy,

    //    /// <summary>
    //    /// 对应数据库中的 "or"
    //    /// </summary>
    //    Or
    //}

    ////private SqlDbType ConvertType(DataType type)
    ////{
    ////    SqlDbType sqlType = SqlDbType.BigInt;
    ////    switch (type)
    ////    {
    ////        case DataType.Bigint:
    ////            sqlType = SqlDbType.BigInt;
    ////            break;
    ////        case DataType.Binary:
    ////            sqlType = SqlDbType.Binary;
    ////            break;
    ////        case DataType.Bit:
    ////            sqlType = SqlDbType.Bit;
    ////            break;
    ////        case DataType.Char:
    ////            sqlType = SqlDbType.Char;
    ////            break;
    ////        case DataType.Datetime:
    ////            sqlType = SqlDbType.DateTime;
    ////            break;
    ////        case DataType.Decimal:
    ////            sqlType = SqlDbType.Decimal;
    ////            break;
    ////        case DataType.Float:
    ////            sqlType = SqlDbType.Float;
    ////            break;
    ////        case DataType.Image:
    ////            sqlType = SqlDbType.Image;
    ////            break;
    ////        case DataType.Int:
    ////            sqlType = SqlDbType.Int;
    ////            break;
    ////        case DataType.Money:
    ////            sqlType = SqlDbType.Money;
    ////            break;
    ////        case DataType.Nchar:
    ////            sqlType = SqlDbType.NChar;
    ////            break;
    ////        case DataType.Ntext:
    ////            sqlType = SqlDbType.NText;
    ////            break;
    ////        case DataType.Numeric:
    ////            sqlType = SqlDbType.Decimal;
    ////            break;
    ////        case DataType.Nvarchar:
    ////            sqlType = SqlDbType.NVarChar;
    ////            break;
    ////        case DataType.Real:
    ////            sqlType = SqlDbType.Float;
    ////            break;
    ////        case DataType.Smalldatetime:
    ////            sqlType = SqlDbType.SmallDateTime;
    ////            break;
    ////        case DataType.Smallint:
    ////            sqlType = SqlDbType.SmallInt;
    ////            break;
    ////        case DataType.Smallmoney:
    ////            sqlType = SqlDbType.SmallMoney;
    ////            break;
    ////        case DataType.Text:
    ////            sqlType = SqlDbType.Text;
    ////            break;
    ////        case DataType.Timestamp:
    ////            sqlType = SqlDbType.Timestamp;
    ////            break;
    ////        case DataType.Tinyint:
    ////            sqlType = SqlDbType.TinyInt;
    ////            break;
    ////        case DataType.Uniqueidentifier:
    ////            sqlType = SqlDbType.UniqueIdentifier;
    ////            break;
    ////        case DataType.Varbinary:
    ////            sqlType = SqlDbType.VarBinary;
    ////            break;
    ////        case DataType.Varchar:
    ////            sqlType = SqlDbType.VarChar;
    ////            break;
    ////        case DataType.Variant:
    ////            sqlType = SqlDbType.Variant;
    ////            break;

    ////    }
    ////    return sqlType;
    ////}
}
