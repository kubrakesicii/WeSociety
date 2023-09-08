using AutoMapper;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.Interfaces;
using WeSociety.Domain.Interfaces;
using WeSociety.Domain.Pagination;

namespace WeSociety.Application.CQRS.Queries.Article.GetAll
{
    public class GetAllArticlesQueryHandler : IQueryHandler<GetAllArticlesQuery, PaginatedList<GetArticleDto>>
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

        public async Task<PaginatedList<GetArticleDto>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await _uow.Articles.GetAllWithUserProfile(request.SearchKey, request.CategoryId);

            //ELK INDEXING
            var existsCheck = await _elasticSearchService.CheckIndexAsync("articles");
            if (!existsCheck)
            {
                articles.ForEach(async a => await _elasticSearchService.CreateIndexAsync("articles", a.Domain,
                    new Domain.Aggregates.ArticleRoot.Article(a.Title, a.Domain, a.Content)));
            }

            var articleDtos = _mapper.Map<List<GetArticleDto>>(articles);
            var paginatedRes = PaginatedResponse<GetArticleDto>.Create(articleDtos, request.PageIndex, request.PageSize);

            return paginatedRes;
        }
    }
}
