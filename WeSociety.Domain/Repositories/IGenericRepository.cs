using System.Linq.Expressions;
using WeSociety.Domain.Common;

namespace WeSociety.Domain.Repository
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
        Task<T> InsertAsync(T entity, CancellationToken cancellationToken);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
