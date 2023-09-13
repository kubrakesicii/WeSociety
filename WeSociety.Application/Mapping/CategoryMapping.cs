using AutoMapper;
using WeSociety.Application.DTO.Category;
using WeSociety.Domain.Aggregates.CategoryRoot;

namespace WeSociety.Application.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, GetCategoryDto>().ReverseMap();
        }
    }
}
