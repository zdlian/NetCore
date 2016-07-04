using System;
using System.Linq;
using System.Linq.Expressions;
using KTU.Core;

namespace KTU.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T: Entity
    {
	    private readonly SimpleDbContext _dbContext;

	    public GenericRepository(SimpleDbContext dbContextFactory)
	    {
		    _dbContext = dbContextFactory;
	    }

	    public void Insert(T entity)
	    {
		    _dbContext.Set<T>().Add(entity);
		    _dbContext.SaveChanges();
	    }

	    public void Delete(T entity)
	    {
		    _dbContext.Remove(entity);
		    _dbContext.SaveChanges();

	    }

	    public IQueryable<T> Get(Expression<Func<T,bool>> func)
	    {
		    return _dbContext.Set<T>().Where(func);
	    }

	    public IQueryable<T> Get()
	    {
		    return _dbContext.Set<T>();
	    }
    }
}
