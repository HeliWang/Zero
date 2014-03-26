using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Core.Web;
using Zero.Core.Pattern;

namespace Zero.Orm
{
    public class Mapper<T> where T :class,new()
    {
        public PetaPoco.Database db = Zero.Orm.ZeroDataContext.GetInstance();

        public T Create(T entity)
        {
           return db.Insert(entity) as T;
        }

        public int Update(T entity)
        {
            return db.Update(entity);
        }

        public int Delete(T entity)
        {
            return db.Delete(entity);
        }

        public int Delete(object primaryKey)
        {
            return db.Delete<T>(primaryKey);
        }

        public bool Exist(object primaryKey)
        {
            return db.Exists<T>(primaryKey);
        }

        public T GetById(object primaryKey)
        {
            return db.SingleOrDefault<T>(primaryKey);
        }

        public Page<T> GetList(int pageIndex, int pageSize, string condition)
        {
            return db.Page<T>(pageIndex, pageSize, condition);
        }
    }
}
