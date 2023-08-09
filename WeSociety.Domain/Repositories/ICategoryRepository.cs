using WeSociety.Domain.Aggregates.CategoryRoot;
using WeSociety.Domain.Repository;

namespace WeSociety.Domain.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
