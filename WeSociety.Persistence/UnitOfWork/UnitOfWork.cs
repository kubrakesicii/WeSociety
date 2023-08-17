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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IArticleCommentRepository _articleCommentRepository;
        private readonly IReadingListRepository _readingListRepository;
        private readonly IReadingListArticleRepository _readingListArticleRepository;
        private readonly IArticleClapRepository _articleClapRepository;
        public UnitOfWork(WeSocietyDbContext context)
        {
            _context = context;
        }

        public IUserProfileRepository UserProfiles => _profileRepository ?? new UserProfileRepository(_context);
        public IArticleRepository Articles => _articleRepository ?? new ArticleRepository(_context);
        public IFollowRelationshipRepository FollowRelationships => _followRelationshipRepository ?? new FollowRelationshipRepository(_context);
        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);
        public IArticleCommentRepository ArticleComments => _articleCommentRepository ?? new ArticleCommentRepository(_context);
        public IReadingListRepository ReadingLists => _readingListRepository ?? new ReadingListRepository(_context);
        public IReadingListArticleRepository ReadingListArticles => _readingListArticleRepository ?? new ReadingListArticleRepository(_context);
        public IArticleClapRepository ArticleClaps => _articleClapRepository ?? new ArticleClapRepository(_context);

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
