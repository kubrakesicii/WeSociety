using Microsoft.EntityFrameworkCore;
using WeSociety.Domain.Aggregates.ArticleRoot.Entities;
using WeSociety.Domain.Repositories;
using WeSociety.Persistence.Context;

namespace WeSociety.Persistence.Repositories
{
    public class ArticleCommentRepository : GenericRepository<ArticleComment>, IArticleCommentRepository
    {
        public ArticleCommentRepository(WeSocietyDbContext context) : base(context)
        {
        }

        public async Task<List<ArticleComment>> GetAllByArticleWithUser(int articleId)
        {
            return await _context.ArticleComments.Include(x => x.UserProfile).Where(x => x.ArticleId==articleId).ToListAsync();
        }
    }
}
