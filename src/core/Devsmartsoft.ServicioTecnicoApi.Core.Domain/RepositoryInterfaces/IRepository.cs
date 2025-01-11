using System.Linq.Expressions;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>>? filter = null);
        Task<T?> GetByFilter(Expression<Func<T, bool>> filter);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task<int> GetTableCount();
    }
}
