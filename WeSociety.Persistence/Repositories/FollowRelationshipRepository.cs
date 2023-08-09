using Microsoft.EntityFrameworkCore;
using WeSociety.Domain.Aggregates.UserProfileRoot.Entities;
using WeSociety.Domain.Repositories;
using WeSociety.Persistence.Context;

namespace WeSociety.Persistence.Repositories
{
    public class FollowRelationshipRepository : GenericRepository<FollowRelationship>, IFollowRelationshipRepository
    {
        public FollowRelationshipRepository(WeSocietyDbContext context) : base(context)
        {
        }

        public async Task<List<FollowRelationship>> GetAllFollowersByUserProfile(int userProfileId)
        {
            return await _context.FollowRelationships.Include(x => x.Follower).Include(x => x.Following).Where(x => x.FollowingId == userProfileId).ToListAsync();
        }

        public async Task<List<FollowRelationship>> GetAllFollowingsByUserProfile(int userProfileId)
        {
            return await _context.FollowRelationships.Include(x => x.Following).Include(x => x.Follower).Where(x => x.FollowerId == userProfileId).ToListAsync();
        }

        public async Task<bool> IsFollowing(int followerId, int followingId)
        {
            return await _context.FollowRelationships.AnyAsync(x => x.FollowerId==followerId && x.FollowingId==followingId);
        }
    }
}
