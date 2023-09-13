using WeSociety.Domain.Aggregates.ArticleRoot;
using WeSociety.Domain.Repository;

namespace WeSociety.Domain.Repositories
{
    public interface IArticleRepository : IGenericRepository<Article>
    {
        Task<List<Article>> GetAllWithUserProfile(int categoryId);
        Task<List<Article>> GetAllWithUserProfileByProfile(int currentUserId, int userProfileId);
        Task<List<Article>> GetAllDraftsWithUserProfileByProfile(int userProfileId);
        Task<Article> GetByIdWithIncludes(int id);
        Task<List<Article>> GetAllPopulars(int categoryId);

    }
}
