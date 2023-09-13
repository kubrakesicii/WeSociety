using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq.Expressions;
using WeSociety.Domain.Aggregates.ArticleRoot;
using WeSociety.Domain.Repositories;
using WeSociety.Persistence.Context;

namespace WeSociety.Persistence.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(WeSocietyDbContext context) : base(context)
        {
        }

        public async Task<List<Article>> GetAllDraftsWithUserProfileByProfile(int userProfileId)
        {
            return await _context.Articles.Include(x => x.UserProfile).Include(x => x.Category)
                .Where(x => x.UserProfileId == userProfileId && !x.IsPublished && x.IsActive)
                .OrderByDescending(x => x.CreatedTime)
                .ToListAsync();
        }

        public async Task<List<Article>> GetAllPopulars(int categoryId)
        {
            Expression<Func<Article, bool>> categoryCond = x => true;
            if (categoryId != 0) categoryCond = x => x.CategoryId == categoryId;
            return await _context.Articles.Include(x => x.UserProfile).Include(x => x.Category)
                .Where(x => x.IsPublished && x.IsActive)
                .Where(categoryCond)
                .OrderByDescending(x => x.ViewCount)
                .Take(5)
                .ToListAsync();

        }

        public async Task<List<Article>> GetAllWithUserProfile(int categoryId)
        {
            Expression<Func<Article, bool>> categoryCond = x => true;
            if (categoryId != 0) categoryCond = x => x.CategoryId == categoryId;

            return await _context.Articles.Include(x => x.UserProfile).Include(x => x.Category)
                .Where(x => x.IsPublished)
                .Where(categoryCond)
                .OrderByDescending(x => x.CreatedTime)
                .ToListAsync();
        }

        public async Task<List<Article>> GetAllWithUserProfileByProfile(int currentUserId, int userProfileId)
        {
            return await _context.Articles.Include(x => x.UserProfile).Include(x => x.Category)
                .Where(x => x.UserProfileId==userProfileId && x.IsPublished && x.IsActive)
                .OrderByDescending(x => x.CreatedTime)
                .ToListAsync();
        }

        public async Task<Article> GetByIdWithIncludes(int id)
        {
            return await _context.Articles.Include(x => x.UserProfile).Include(x => x.Category)
                .Include(x => x.ArticleClaps)
                .Include(x => x.ArticleComments)
                .Where(x => x.Id==id)
                .FirstOrDefaultAsync();
        }
    }
}
