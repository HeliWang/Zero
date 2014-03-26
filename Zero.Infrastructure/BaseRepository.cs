using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Zero.DomainModel;

namespace Zero.Infrastructure
{
	public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class,new()
	{
		public bool Exist(Expression<Func<TEntity, bool>> condition)
		{
			throw new NotImplementedException();
		}

		public void Save(TEntity entity)
		{
			throw new NotImplementedException();
		}
	}
}
