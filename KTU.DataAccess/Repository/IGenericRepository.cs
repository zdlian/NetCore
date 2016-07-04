using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KTU.Core;

namespace KTU.DataAccess.Repository
{
    public interface IGenericRepository<T> where T : Entity
    {
	    void Insert(T entity);
	    void Delete(T entity);

		IQueryable<T> Get(Expression<Func<T,bool>> func);

	    IQueryable<T> Get();
    }
}
