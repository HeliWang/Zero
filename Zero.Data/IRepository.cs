using System;
using System.Linq;
using System.Data.Entity;
using Zero.Domain;

namespace Zero.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(string ids);
        IQueryable<T> Table { get; }
        DbSet<T> Entities { get; }
    }
}
