using Microsoft.EntityFrameworkCore;
using WeSociety.Domain.Aggregates.ReadingListRoot.Entities;
using WeSociety.Domain.Repositories;
using WeSociety.Persistence.Context;

namespace WeSociety.Persistence.Repositories
{
    public class ReadingListArticleRepository : GenericRepository<ReadingListArticle>, IReadingListArticleRepository
    {
        public ReadingListArticleRepository(WeSocietyDbContext context) : base(context)
        {
        }

        public async Task<List<ReadingListArticle>> GetAllArticlesOfReadingList(int readingListId)
        {
            return await _context.ReadingListArticles
                .Include(x => x.Article).ThenInclude(x => x.UserProfile)
                .Include(x => x.Article).ThenInclude(x => x.Category)
                .Where(x => x.ReadingListId == readingListId).ToListAsync();
        }

        public async Task<ReadingListArticle> GetIsArticleSaved(int userProfileId, int articleId)
        {
            return await _context.ReadingListArticles.Include(x => x.Article)
                .Include(x => x.ReadingList).ThenInclude(x => x.UserProfile)
                .Where(x => x.ArticleId == articleId && x.ReadingList.UserProfileId == userProfileId)
                .FirstOrDefaultAsync();
        }
    }
}
