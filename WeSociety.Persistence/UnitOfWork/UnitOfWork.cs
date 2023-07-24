using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Interfaces;
using WeSociety.Persistence.Context;

namespace WeSociety.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private WeSocietyDbContext _context;

        public UnitOfWork(WeSocietyDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
