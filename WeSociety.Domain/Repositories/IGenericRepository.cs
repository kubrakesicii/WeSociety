using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Base;

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
