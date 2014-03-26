using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Zero.DomainModel
{
	public interface IRepository<TEntity> where TEntity : class,new()
	{
		void Save(TEntity entity);
		Boolean Exist(Expression<Func<TEntity, bool>> condition);
	}
}
