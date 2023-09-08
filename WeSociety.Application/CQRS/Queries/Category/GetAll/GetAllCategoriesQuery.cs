using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Category;

namespace WeSociety.Application.CQRS.Queries.Category.GetAll
{
    public class GetAllCategoriesQuery : IQuery<List<GetCategoryDto>>
    {
    }
}
