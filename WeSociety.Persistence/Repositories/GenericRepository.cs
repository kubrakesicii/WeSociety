using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WeSociety.Domain.Common;
using WeSociety.Domain.Repository;
using WeSociety.Persistence.Context;

namespace WeSociety.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected WeSocietyDbContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(WeSocietyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task Delete(T entity)
        {
            await Task.Run(() => { _context.Remove(entity); });
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(filter,cancellationToken);
        }

        public async Task<T> InsertAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity,cancellationToken);
            return entity;
        }

        public async Task Update(T entity)
        {
            await Task.Run(() => { _context.Update(entity); });
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(filter).ToListAsync(cancellationToken);
        }
    }
}
