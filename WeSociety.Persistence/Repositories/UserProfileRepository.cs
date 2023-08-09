using Microsoft.EntityFrameworkCore;
using WeSociety.Domain.Aggregates.UserProfileRoot;
using WeSociety.Domain.Repositories;
using WeSociety.Persistence.Context;

namespace WeSociety.Persistence.Repositories
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(WeSocietyDbContext context) : base(context)
        {
        }

        public async Task<UserProfile> GetWithUserAsync(int id)
        {
            return await _context.UserProfiles.
                Include(x => x.Followers)
                .Include(x => x.Followings)
                .Include(x => x.User).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
