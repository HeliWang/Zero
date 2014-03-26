using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Linq.Expressions;
using Zero.Domain;


namespace Zero.Data
{
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context; 
        private DbSet<T> _entities;

        public EfRepository()
        {
            _context = new EfDbContext();
            this._entities = _context.Set<T>();
        }

        public EfRepository(DbContext context)
        {
            this._context = context;
        }

        public T Add(T entity)
        {
            T t = this._entities.Add(entity);
            this._context.SaveChanges();
            return t;
        }

        public void Update(T entity)
        {
            this._context.SaveChanges();
        }

        public void Delete(T entity)
        {
            this._entities.Remove(entity);
            this._context.SaveChanges();
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

        //public virtual IQueryable<T> Table
        //{
        //    get
        //    {
        //        return this.Entities;
        //    }
        //}

        //private IDbSet<T> Entities
        //{
        //    get
        //    {
        //        if (_entities == null)
        //            _entities = _context.Set<T>();
        //        return _entities;
        //    }
        //}
    }
}
