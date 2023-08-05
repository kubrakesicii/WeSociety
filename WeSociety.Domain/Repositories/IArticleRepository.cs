using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.AggregateRoots.UserProfile.Entities;
using WeSociety.Domain.Repository;

namespace WeSociety.Domain.Repositories
{
    public interface IArticleRepository : IGenericRepository<Article>
    {
        Task<List<Article>> GetAllWithUserProfile(string searchKey,int categoryId);
        Task<List<Article>> GetAllWithUserProfileByProfile(int currentUserId, int userProfileId);
        Task<Article> GetByIdWithIncludes(int id);
        Task<List<Article>> GetAllPopulars(int categoryId);

    }
}
