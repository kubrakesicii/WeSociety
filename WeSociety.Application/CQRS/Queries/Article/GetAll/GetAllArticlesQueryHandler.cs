using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.Interfaces;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;
using WeSociety.Domain.Pagination;

namespace WeSociety.Application.CQRS.Queries.Article.GetAll
{
    public class GetAllArticlesQueryHandler : IQueryHandler<GetAllArticlesQuery, DataResponse<PaginatedList<GetArticleDto>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IElasticSearchService<Domain.Aggregates.ArticleRoot.Article> _elasticSearchService;
        public GetAllArticlesQueryHandler(IUnitOfWork uow, IMapper mapper, IElasticSearchService<Domain.Aggregates.ArticleRoot.Article> elasticSearchService)
        {
            _uow = uow;
            _mapper = mapper;
            _elasticSearchService = elasticSearchService;
        }

        public async Task<DataResponse<PaginatedList<GetArticleDto>>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await _uow.Articles.GetAllWithUserProfile(request.SearchKey, request.CategoryId);

            //ELK INDEXING
            var existsCheck = await _elasticSearchService.CheckIndex("articles");
            if (!existsCheck)
            {
                articles.ForEach(async a => await _elasticSearchService.CreateIndex("articles", new Domain.Aggregates.ArticleRoot.Article(a.Title, a.Domain, a.Content)));
            }

            var articleDtos = _mapper.Map<List<GetArticleDto>>(articles);
            var paginatedRes = PaginatedResponse<GetArticleDto>.Create(articleDtos, request.PageIndex, request.PageSize);

            return new SuccessDataResponse<PaginatedList<GetArticleDto>>(paginatedRes);
        }
    }
}
