using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Aggregates.ArticleRoot.Entities;
using WeSociety.Domain.Repositories;
using WeSociety.Persistence.Context;

namespace WeSociety.Persistence.Repositories
{
    public class ArticleClapRepository : GenericRepository<ArticleClap>, IArticleClapRepository
    {
        public ArticleClapRepository(WeSocietyDbContext context) : base(context)
        {
        }

        public async Task<List<ArticleClap>> GetAllByArticleWithUser(int articleId)
        {
            return await _context.ArticleClaps.Include(x => x.Article)
                .Include(x => x.UserProfile).ThenInclude(x => x.User).Where(x => x.ArticleId == articleId)
                .ToListAsync();
        }
    }
}
