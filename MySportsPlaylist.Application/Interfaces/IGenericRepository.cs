using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace MySportsPlaylist.Application.Interfaces;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetAll(
       Expression<Func<T, bool>> filter = null,
       Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

    Task<T> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    void Remove(T entity);
}
