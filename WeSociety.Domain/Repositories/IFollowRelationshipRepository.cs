using WeSociety.Domain.Aggregates.UserProfileRoot.Entities;
using WeSociety.Domain.Repository;

namespace WeSociety.Domain.Repositories
{
    public interface IFollowRelationshipRepository : IGenericRepository<FollowRelationship>
    {
        Task<List<FollowRelationship>> GetAllFollowersByUserProfile(int userProfileId);
        Task<List<FollowRelationship>> GetAllFollowingsByUserProfile(int userProfileId);
        Task<bool> IsFollowing(int followerId, int followingId);
    }
}
