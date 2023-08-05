using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.Article.GetAllPopulars
{
    public class GetAllPopularArticlesQueryHandler : IQueryHandler<GetAllPopularArticlesQuery, DataResponse<List<GetArticleDto>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllPopularArticlesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<DataResponse<List<GetArticleDto>>> Handle(GetAllPopularArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await _uow.Articles.GetAllPopulars(request.CategoryId);
            var articleDto = _mapper.Map<List<GetArticleDto>>(articles);
            return new SuccessDataResponse<List<GetArticleDto>>(articleDto);
        }
    }
}
