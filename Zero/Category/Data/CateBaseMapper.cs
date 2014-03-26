using System.Collections.Generic;
using System.Text;
using Zero.Category.Model;
using PetaPoco;
using Zero.Orm;


namespace Zero.Category.Data
{
    public class CateBaseMapper<T>: Mapper<T> where T : class,new()
    {
        /// <summary>
        /// 表名
        /// </summary>
        private string table { get; set; }

        public string Table
        {
            set { this.table = value; }
            get { return this.table; }
        }

        public CateBaseMapper()
        {
            
        }

        public CateBaseMapper(string table)
        {
            this.table = table;
        }

        /// <summary>
        /// 添加类别
        /// </summary>
        public void Create(string cateName, int pid)
        {
            db.ExecuteScalar<int>("execute [SB_CategoryInsert] @0,@1,@2", cateName, pid, table);
        }

        /// <summary>
        /// 更新类别信息
        /// </summary>
        public void Update(int cateId, string cateName)
        {
            db.Execute("execute [SB_CategoryUpdate] @0,@1,@2", cateId, cateName, table);
        }

        //删除类别
        public int Delete(int cateId)
        {
            return db.Execute("execute [SB_CategoryDelete] @0,@1", cateId, table);
        }

        /// <summary>
        /// 修改所属类别
        /// </summary>
        public void ChangeParent(int cateId, int pid)
        {
            db.Execute("execute [SB_CategoryChangeParent] @0,@1,@2", cateId, pid, table);
        }

        /// <summary>
        /// 判断是否存在此类别
        /// </summary>
        public bool ExistCateId(int cateId)
        {
            return db.Exists<T>("CateId=@0 ", cateId);
        }

        /// <summary>
        /// 判断同一父节点并且同级别的类目是否出现同名
        /// </summary>
        public bool ExistCateName(string cateName, int pid, int depth)
        {
            return db.Exists<T>("CateName=@0 and Pid=@1 and depth=@2", cateName, pid, depth);
        }

        /// <summary>
        /// 判断同一父节点并且同级别的类目是否出现同名
        /// </summary>
        public bool ExistCateName(int cateId, string cateName, int pid, int depth)
        {
            return db.Exists<T>("cateId<>@0 and CateName=@1 and Pid=@2 and depth=@3", cateId,cateName, pid, depth);
        }

        /// <summary>
        /// 获取父亲类别 ，倒序 , 第一个为最亲近的父亲节点
        /// </summary>
        public List<T> GetCateParent(int cateId)
        {
            return db.Fetch<T>("execute [SB_CategoryGetParent] @0,@1", cateId, table);
        }

        /// <summary>
        /// 获取类别的路径 
        /// </summary>
        public List<T> GetCatePath(int cateId)
        {
            return db.Fetch<T>("execute [SB_CategoryGetPath] @0,@1", cateId, table);
        }

        /// <summary>
        /// 获取类别列表 (depth=-1为自身，depth=0 为所有子节点 , depth>0为指定深度的子节点)
        /// </summary>
        public List<T> GetCateList(int cateId, int depth)
        {
            return db.Fetch<T>("execute [SB_CategorySelect] @0,@1,@2", cateId, depth, table);
        }
    }
}
