using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public async Task<T> Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task Update(T entity)
        {
            await Task.Run(() => { _context.Update(entity); });
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }
    }
}
