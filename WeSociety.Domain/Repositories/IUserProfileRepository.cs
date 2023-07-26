using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.AggregateRoots.UserProfile;
using WeSociety.Domain.Repository;

namespace WeSociety.Domain.Repositories
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        Task<UserProfile> GetWithUserAsync(int id);
    }
}
