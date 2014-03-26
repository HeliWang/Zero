using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Orm
{
	public interface IMapper<T>
	{
		T Insert(T entity);
		int Update(T entity);
		int Delete(T entity);
		T GetById(object id);
		List<T> GetList();
	}
}
