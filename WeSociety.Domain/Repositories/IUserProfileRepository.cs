using WeSociety.Domain.Aggregates.UserProfileRoot;
using WeSociety.Domain.Repository;

namespace WeSociety.Domain.Repositories
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        Task<UserProfile> GetWithUserAsync(int id);
    }
}
