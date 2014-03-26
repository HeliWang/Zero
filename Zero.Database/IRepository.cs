using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Data
{
    /// <summary>
    /// Repository
    /// </summary>
    public partial interface IRepository<T> where T : class,new()
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(object id);
        List<T> GetList();
    }
}
