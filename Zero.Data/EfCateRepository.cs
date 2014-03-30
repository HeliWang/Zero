using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Linq.Expressions;
using Zero.Domain;
using Zero.Domain.Cates;

namespace Zero.Data
{
    /// <summary>
    /// http://www.cnblogs.com/mend/archive/2012/06/11/2544599.html
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfCateRepository<T> : IRepository<T> where T : BaseCate
    {
        private readonly DbContext _context;
        private DbSet<T> _entities;

        public string TableName { get; set; }

        public EfCateRepository(string tableName)
        {
            _context = new EfDbContext();
            this._entities = _context.Set<T>();
            this.TableName = tableName;
        }

        public EfCateRepository(DbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 添加类别
        /// </summary>
        public T Add(T entity)
        {
            entity.CateId = _context.Database.ExecuteSqlCommand("execute [SB_CategoryInsert] {0},{1},{2}", entity.CateName, entity.Pid, this.TableName);
            return entity;
        }

        /// <summary>
        /// 更新类别
        /// </summary>
        public void Update(T entity)
        {
            _context.Database.ExecuteSqlCommand("execute [SB_CategoryUpdate] {0},{1},{2}", entity.CateId, entity.CateName, this.TableName);
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        public void Delete(string cateIds)
        {
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        public void Delete(int cateId)
        {
            _context.Database.ExecuteSqlCommand("execute [SB_CategoryDelete] {0},{1}", cateId, this.TableName);
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        public void Delete(T entity)
        {
            Delete(entity.CateId);
        }

        /// <summary>
        /// 修改所属类别
        /// </summary>
        public void ChangeParent(T entity)
        {
            _context.Database.ExecuteSqlCommand("execute [SB_CategoryChangeParent] {0},{1},{2}", entity.CateId, entity.Pid, this.TableName);
        }

        /// <summary>
        /// 判断同一父节点并且同级别的类目是否出现同名
        /// </summary>
        public bool ExistNameByAdd(T entity)
        {
            var query = _entities.SingleOrDefault(c => c.CateName == entity.CateName && c.Pid == entity.Pid && c.Depth == entity.Depth);
            return query != null ? true : false;
        }

        /// <summary>
        /// 判断同一父节点并且同级别的类目是否出现同名,排除自身
        /// </summary>
        public bool ExistNameByUpdate(T entity)
        {
            //string sql = "select count(*) from {4} where CateId<>{0} and CateName={1} and Pid={2} and depth={3}";
            //int count = _context.Database.SqlQuery<int>(sql, entity.CateId, entity.CateName, entity.Pid, entity.Depth, this.TableName).ToList()[0];
            //return count > 0 ? true : false;

            var query = _entities.SingleOrDefault(c => c.CateId != entity.CateId && c.CateName == entity.CateName && c.Pid == entity.Pid && c.Depth == entity.Depth);
            return query != null ? true : false;

        }

        /// <summary>
        /// 获取父亲类别 ，倒序 , 第一个为最亲近的父亲节点
        /// </summary>
        public List<T> GetParent(int cateId)
        {
            return _context.Database.SqlQuery<T>("execute [SB_CategoryGetParent] {0},{1}", cateId, this.TableName).ToList();
        }

        /// <summary>
        /// 获取类别的路径 
        /// </summary>
        public List<T> GetPath(int cateId)
        {
            return _context.Database.SqlQuery<T>("execute [SB_CategoryGetPath] {0},{1}", cateId, this.TableName).ToList();
        }

        /// <summary>
        /// 获取类别列表 (depth=-1为自身，depth=0 为所有子节点 , depth>0为指定深度的子节点)
        /// </summary>
        public List<T> GetList(int cateId, int depth)
        {
            return _context.Database.SqlQuery<T>("execute [SB_CategorySelect] {0},{1},{2}", cateId, depth, this.TableName).ToList();
        }



        public T GetById(object id)
        {
            return this._entities.Find(id);
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        public DbSet<T> Entities
        {
            get
            {
                return _entities;
            }
        }
    }
}
