using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.AggregateRoots.UserProfile.Entities;
using WeSociety.Domain.Repository;

namespace WeSociety.Domain.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
