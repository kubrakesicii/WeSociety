using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.AggregateRoots.UserProfile;
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
            return await _context.UserProfiles.Include(x => x.User).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
