using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Category;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.Category.GetAll
{
    public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, DataResponse<List<GetCategoryDto>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<DataResponse<List<GetCategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var cats = await _uow.Categories.GetAll();
            return new SuccessDataResponse<List<GetCategoryDto>>(_mapper.Map<List<GetCategoryDto>>(cats));
        }
    }
}
