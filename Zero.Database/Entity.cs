using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace Zero.Data
{
    #region Model: Attribute
   
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public TableAttribute() { }

        public TableAttribute(string name, string primaryKey) 
        { 
            this.Name = name; 
            this.PrimaryKey = primaryKey;
        }

        public string Name { get; set; }

        public string PrimaryKey { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAttribute : Attribute
    {
        //public bool IgnoreInsert { get; set; }
        //public bool IgnoreUpdate { get; set; }
        //public bool IgnoreSelect { get; set; }

        //public IgnoreAttribute()
        //{
        //    this.IgnoreInsert = true;
        //    this.IgnoreUpdate = true;
        //    this.IgnoreSelect = true;
        //}
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreInsertAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreUpdateAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreSelectAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {
    }

    //public class ColoumAttribute : Attribute
    //{
    //}

    [Table(Name = "Product_Base", PrimaryKey = "PorductID")]
    public class ProdcutInfo
    {
        [PrimaryKey]
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        [IgnoreInsert]
        [IgnoreUpdate]
        [IgnoreSelect]
        public decimal Price { get; set; }

        [Ignore]
        public DateTime CreateTime { get; set; }
    }

    #endregion

    #region Model: Info

    public class TableInfo
    {
        public string Name { get; set; }
        public string PrimaryKey { get; set; }

        public Dictionary<string, ColumnInfo> ColumnList { get; set; }
    }

    public class ColumnInfo
    {
        public string Name { get; set; }

        public bool IsPrimaryKey { get; set; }

        public bool IsIgnoreInsert { get; set; }

        public bool IsIgnoreUpdate { get; set; }

        public bool IsIgnoreSelect { get; set; }

        public PropertyInfo PropertyInfo { get; set; }
    }

    #endregion

    public class EntityHelper
    {
        public static TableInfo GetEntityInfo(Type t)
        {
            TableInfo info = new TableInfo();
            info.ColumnList = new Dictionary<string, ColumnInfo>();

            
            var tableAttribute = t.GetCustomAttributes(typeof(TableAttribute), false) as TableAttribute[];

            info.Name = tableAttribute[0].Name;
            info.PrimaryKey = tableAttribute[0].PrimaryKey;

            foreach (var propertie in t.GetProperties())
            {
                ColumnInfo columnInfo = new ColumnInfo();
                columnInfo.Name = propertie.Name;
                columnInfo.PropertyInfo = propertie;

                var primaryKeyAttribute = propertie.GetCustomAttributes(typeof(PrimaryKeyAttribute), false) as PrimaryKeyAttribute[];
                var ignoreAttribute = propertie.GetCustomAttributes(typeof(IgnoreAttribute), false) as IgnoreAttribute[];

                if (primaryKeyAttribute.Length > 0) columnInfo.IsPrimaryKey = true;
                if (ignoreAttribute.Length > 0)
                {
                    columnInfo.IsIgnoreInsert = true;
                    columnInfo.IsIgnoreUpdate = true;
                    columnInfo.IsIgnoreSelect = true;
                }
                else
                {
                    var ignoreInsertAttribute = propertie.GetCustomAttributes(typeof(IgnoreInsertAttribute), false) as IgnoreInsertAttribute[];
                    var ignoreUpdateAttribute = propertie.GetCustomAttributes(typeof(IgnoreUpdateAttribute), false) as IgnoreUpdateAttribute[];
                    var ignoreSelectAttribute = propertie.GetCustomAttributes(typeof(IgnoreSelectAttribute), false) as IgnoreSelectAttribute[];

                    if (ignoreInsertAttribute.Length > 0) columnInfo.IsIgnoreInsert = true;

                    if (ignoreUpdateAttribute.Length > 0) columnInfo.IsIgnoreUpdate = true;

                    if (ignoreSelectAttribute.Length > 0) columnInfo.IsIgnoreSelect = true;
                }

                info.ColumnList.Add(columnInfo.Name, columnInfo);
            }

            //foreach (var field in t.GetFields())
            //{
            //}
            
            return info;
        }

        public static TableInfo GetEntityInfo(object obj)
        {
            var t = obj.GetType();
            return GetEntityInfo(t);
        }
    }


    public class Sql
    {
        public static string GetInsertSql(string tableName, string[] fieldList)
        {
            //List<string> names = new List<string>();
            //List<string> values = new List<string>();

            //List<IDataParameter> paramList = new List<IDataParameter>();
            //foreach (var columnInfo in table.ColumnList)
            //{
            //    if (columnInfo.Name != table.PrimaryKey)
            //    {
            //        names.Add(columnInfo.Name);
            //        values.Add(string.Format("@{0}", columnInfo.Name));
            //    }

            //    var propertie = columnInfo.PropertyInfo;


            //    //paramList.Add(new IDataParameter());
            //}

            //string sb = string.Format("insert into {0} ({1}) values({2})", 
            //    table.Name,
            //    string.Join(",", names.ToArray()),
            //    string.Join(",", values.ToArray())
            //    );

            string sb = string.Format("insert into [{0}] ({1}) values({2})",
                tableName,
                string.Join(",", fieldList),
                "@" + string.Join(",@", fieldList)
                );

            return sb;
        }

        public static string GetUpdateSql(string tableName, string fields, string where)
        {
            string sb = string.Format("update [{0}] set {1} where {2}", tableName, fields, where);


            return sb.ToString();
        }

        public string GetSelectSql()
        {
            return "select * from [TableName] where ID=@ID and sex='难' order by ID des  group by ID";
        }

        public void Select()
        {
        }

        public void From()
        {
        }

        public void Where()
        {
        }

        public void GroupBy()
        {
        }

        public void OrderBy()
        {
        }
    }
}
