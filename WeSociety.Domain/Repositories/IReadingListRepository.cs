using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Aggregates.ReadingListRoot;
using WeSociety.Domain.Repository;

namespace WeSociety.Domain.Repositories
{
    public interface IReadingListRepository : IGenericRepository<ReadingList>
    {
        Task<List<ReadingList>> GetAllReadingLists(int userProfileId);
    }
}
