using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Zero.Core.DataProvider
{
    public partial class SqlHelper
    {
        #region Connection构造器

        public static string _connectionString = null;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = Zero.Core.Config.DataBase.ConnectionString;
                }

                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        #endregion 私有构造函数和方法结束


        #region SqlCommand构造器

        /// <summary>
        /// 预编译管理器
        /// </summary>
        public static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction trans, string cmdText, CommandType type, params SqlParameter[] commandParameters)
        {
            command.Connection = connection;

            command.CommandText = cmdText;

            command.CommandType = type;

            if (trans != null)
            {
                command.Transaction = trans;
            }

            if (commandParameters != null)
            {
                command.Parameters.AddRange(commandParameters);
            }

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }


        /// <summary>
        /// 添加参数
        /// </summary>
        public static SqlParameter MakeInParameter(string name, SqlDbType type, int size, object value)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = name;
            parameter.SqlDbType = type;
            parameter.Size = size;
            parameter.SqlValue = value;
            return parameter;
        }

        #endregion 结束


        #region  ExecuteNonQuery 构造器

        public static int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(cmdText, CommandType.Text, null);
        }

        public static int ExecuteNonQuery(string cmdText, CommandType type)
        {
            return ExecuteNonQuery(cmdText, type, null);
        }

        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(cmdText, CommandType.Text, commandParameters);
        }

        /// <summary>
        /// 不带事务
        /// </summary>
        public static int ExecuteNonQuery(string cmdText, CommandType type, params SqlParameter[] commandParameters)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand();
            PrepareCommand(command, connection, null, cmdText, type, commandParameters);
            int value = command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
            return value;
        }

        public static int ExecuteNonQuery(SqlTransaction trans, string cmdText)
        {
            return ExecuteNonQuery(trans, cmdText, CommandType.Text, null);
        }

        public static int ExecuteNonQuery(SqlTransaction trans, string cmdText, CommandType type)
        {
            return ExecuteNonQuery(trans, cmdText, type, null);
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        public static int ExecuteNonQuery(SqlTransaction trans, string cmdText, CommandType type, params SqlParameter[] commandParameters)
        {
            SqlCommand command = new SqlCommand();
            PrepareCommand(command, trans.Connection, trans, cmdText, type, commandParameters);
            int value = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return value;
        }




        #endregion


        #region  ExecuteScalar 构造器

        public static object ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(cmdText, CommandType.Text, null);
        }

        public static object ExecuteScalar(string cmdText, CommandType type)
        {
            return ExecuteScalar(cmdText, type, null);
        }

        public static object ExecuteScalar(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(cmdText, CommandType.Text, commandParameters);
        }

        public static object ExecuteScalar(string cmdText, CommandType type, params SqlParameter[] commandParameters)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand();
            PrepareCommand(command, connection, null, cmdText, type, commandParameters);
            object value = command.ExecuteScalar();
            command.Parameters.Clear();
            connection.Close();
            return value;
        }


        public static object ExecuteScalar(SqlTransaction trans, string cmdText)
        {
            return ExecuteScalar(trans, cmdText, CommandType.Text, null);
        }

        public static object ExecuteScalar(SqlTransaction trans, string cmdText, CommandType type)
        {
            return ExecuteScalar(trans, cmdText, type, null);
        }

        /// <summary>
        /// 带事务，数据库链接未关闭
        /// </summary>
        public static object ExecuteScalar(SqlTransaction trans, string cmdText, CommandType type, params SqlParameter[] commandParameters)
        {
            SqlCommand command = new SqlCommand();
            PrepareCommand(command, trans.Connection, trans, cmdText, type, commandParameters);
            object value = command.ExecuteScalar();
            command.Parameters.Clear();
            return value;
        }

        #endregion


        #region  ExecuteReader 构造器

        public static SqlDataReader ExecuteReader(string cmdText)
        {
            return ExecuteReader(cmdText, CommandType.Text, null);
        }

        public static SqlDataReader ExecuteReader(string cmdText, CommandType type)
        {
            return ExecuteReader(cmdText, type, null);
        }

        public static SqlDataReader ExecuteReader(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteReader(cmdText, CommandType.Text, commandParameters);
        }

        public static SqlDataReader ExecuteReader(string cmdText, CommandType type, params SqlParameter[] commandParameters)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand();
            //预处理
            PrepareCommand(command, connection, null, cmdText, type, commandParameters);
            //执行操作，并关闭数据库
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
            command.Parameters.Clear();
            return dr;
        }


        public static SqlDataReader ExecuteReader(SqlTransaction trans, string cmdText)
        {
            return ExecuteReader(trans, cmdText, CommandType.Text, null);
        }

        public static SqlDataReader ExecuteReader(SqlTransaction trans, string cmdText, CommandType type)
        {
            return ExecuteReader(trans, cmdText, type, null);
        }

        public static SqlDataReader ExecuteReader(SqlTransaction trans, string cmdText, CommandType type, params SqlParameter[] commandParameters)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand();
            //预处理
            PrepareCommand(command, trans.Connection, trans, cmdText, type, commandParameters);
            //执行操作，并关闭数据库
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
            command.Parameters.Clear();
            return dr;
        }

        #endregion



        #region  ExecuteDataSet 构造器

        public static DataSet ExecuteDataSet(string cmdText)
        {
            return ExecuteDataSet(cmdText, CommandType.Text, null);
        }

        public static DataSet ExecuteDataSet(string cmdText, CommandType type)
        {
            return ExecuteDataSet(cmdText, type, null);
        }

        public static DataSet ExecuteDataSet(SqlTransaction trans, string cmdText)
        {
            return ExecuteDataSet(trans, cmdText, CommandType.Text, null);
        }

        public static DataSet ExecuteDataSet(string cmdText, CommandType type, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                PrepareCommand(command, connection, null, cmdText, type, commandParameters);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                command.Parameters.Clear();
                connection.Close();
                return ds;
            }
        }



        public static DataSet ExecuteDataSet(SqlTransaction trans, string cmdText, CommandType type)
        {
            return ExecuteDataSet(trans, cmdText, type);
        }

        public static DataSet ExecuteDataSet(SqlTransaction trans, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(trans, cmdText, CommandType.Text, commandParameters);
        }

        public static DataSet ExecuteDataSet(SqlTransaction trans, string cmdText, CommandType type, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                PrepareCommand(command, trans.Connection, trans, cmdText, type, commandParameters);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                command.Parameters.Clear();
                connection.Close();
                return ds;
            }
        }

        #endregion


    }

    public partial class SqlHelper
    {
        /// <summary>
        /// 获取分页列表,不返回总数
        /// </summary>
        public static SqlDataReader GetList(string table, string primaryId, string where, string sort, int pageSize, int pageIndex)
        {
            SqlParameter[] parms =
            {
                MakeInParameter("tableName",SqlDbType.NVarChar,50,table),
                MakeInParameter("pagesize",SqlDbType.Int,0,pageSize),
                MakeInParameter("pageindex",SqlDbType.Int,0,pageIndex),
                MakeInParameter("condition",SqlDbType.NVarChar,4000,where),
                MakeInParameter("primaryid",SqlDbType.NVarChar,100,primaryId),
                MakeInParameter("sortexpression",SqlDbType.NVarChar,100,sort),
            };

            return ExecuteReader("Page_GetList", CommandType.StoredProcedure, parms);
        }

        /// <summary>
        /// 获取分页列表,包含返回的条数
        /// </summary>
        public static SqlDataReader GetList(out int count, string table, string primaryId, int pageSize, int pageIndex, string condition, string sort)
        {
            count = GetCount(table, condition);
            return GetList(table, primaryId, condition, sort, pageSize, pageIndex);
        }

        /// <summary>
        /// 返回记录总条数
        /// </summary>
        public static int GetCount(string table, string condition)
        {
            string sql = string.Format("select count(*) from {0} where {1}", table, condition);
            return Convert.ToInt32(ExecuteScalar(sql));
        }
    }
}
