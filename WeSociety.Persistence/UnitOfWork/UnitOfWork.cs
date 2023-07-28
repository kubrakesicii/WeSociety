using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Interfaces;
using WeSociety.Domain.Repositories;
using WeSociety.Persistence.Context;
using WeSociety.Persistence.Repositories;

namespace WeSociety.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private WeSocietyDbContext _context;

        private readonly IUserProfileRepository _profileRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IFollowRelationshipRepository _followRelationshipRepository;
        public UnitOfWork(WeSocietyDbContext context)
        {
            _context = context;
        }

        public IUserProfileRepository UserProfiles => _profileRepository ?? new UserProfileRepository(_context);
        public IArticleRepository Articles => _articleRepository ?? new ArticleRepository(_context);
        public IFollowRelationshipRepository FollowRelationships => _followRelationshipRepository ?? new FollowRelationshipRepository(_context);

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
