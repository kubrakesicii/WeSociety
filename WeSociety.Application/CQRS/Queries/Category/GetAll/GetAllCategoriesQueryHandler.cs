using AutoMapper;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Category;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.Category.GetAll
{
    public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, List<GetCategoryDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var cats = await _uow.Categories.GetAllAsync(x => x.IsActive == true, cancellationToken);
            return _mapper.Map<List<GetCategoryDto>>(cats);
        }
    }
}
