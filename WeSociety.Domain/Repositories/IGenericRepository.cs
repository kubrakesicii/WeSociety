using System.Linq.Expressions;
using WeSociety.Domain.Common;

namespace WeSociety.Domain.Repository
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<T> Insert(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
