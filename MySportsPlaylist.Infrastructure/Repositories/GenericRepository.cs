using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MySportsPlaylist.Application.Interfaces;
using MySportsPlaylist.Infrastructure.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MySportsPlaylist.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ApplicationDbContext _dbContext;
    protected readonly DbSet<T> _dbSet;
    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        IQueryable<T> query = _dbSet;
        if (filter != null) 
            query = query.Where(filter);
        if (include != null)
            query = include(query);
        return query;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }
}
