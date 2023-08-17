using WeSociety.Domain.Aggregates.ReadingListRoot.Entities;
using WeSociety.Domain.Repository;

namespace WeSociety.Domain.Repositories
{
    public interface IReadingListArticleRepository : IGenericRepository<ReadingListArticle>
    {
        Task<List<ReadingListArticle>> GetAllArticlesOfReadingList(int readingListId);
        Task<ReadingListArticle> GetIsArticleSaved(int userProfileId, int articleId);
    }
}
