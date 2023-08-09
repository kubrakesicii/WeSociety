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
    }
}
