using WeSociety.Domain.Aggregates.CategoryRoot;
using WeSociety.Domain.Repositories;
using WeSociety.Persistence.Context;

namespace WeSociety.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(WeSocietyDbContext context) : base(context)
        {
        }
    }
}
