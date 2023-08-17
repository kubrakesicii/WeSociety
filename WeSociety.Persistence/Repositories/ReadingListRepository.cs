using Microsoft.EntityFrameworkCore;
using WeSociety.Domain.Aggregates.ReadingListRoot;
using WeSociety.Domain.Repositories;
using WeSociety.Persistence.Context;

namespace WeSociety.Persistence.Repositories
{
    public class ReadingListRepository : GenericRepository<ReadingList>, IReadingListRepository
    {
        public ReadingListRepository(WeSocietyDbContext context) : base(context)
        {
        }

        public async Task<List<ReadingList>> GetAllReadingLists(int userProfileId)
        {
            return await _context.ReadingLists.Include(x => x.ReadingListArticles).ThenInclude(x => x.Article)
                .Where(x => x.UserProfileId == userProfileId)
                .ToListAsync();
        }
    }
}
