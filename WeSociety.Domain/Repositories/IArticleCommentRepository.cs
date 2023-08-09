using WeSociety.Domain.Aggregates.ArticleRoot.Entities;
using WeSociety.Domain.Repository;

namespace WeSociety.Domain.Repositories
{
    public interface IArticleCommentRepository : IGenericRepository<ArticleComment>
    {
    }
}
