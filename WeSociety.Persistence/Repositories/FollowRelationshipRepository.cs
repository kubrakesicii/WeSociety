using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.AggregateRoots.UserProfile.Entities;
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
            return await _context.FollowRelationships.Include(x => x.Follower).ThenInclude(x => x.User).Where(x => x.FollowingId == userProfileId).ToListAsync();
        }

        public async Task<List<FollowRelationship>> GetAllFollowingsByUserProfile(int userProfileId)
        {
            return await _context.FollowRelationships.Include(x => x.Following).ThenInclude(x => x.User).Where(x => x.FollowerId == userProfileId).ToListAsync();
        }
    }
}
