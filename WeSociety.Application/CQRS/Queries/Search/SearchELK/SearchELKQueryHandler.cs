using AutoMapper;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.DTO.Search;
using WeSociety.Application.DTO.UserProfile;
using WeSociety.Application.Interfaces;

namespace WeSociety.Application.CQRS.Queries.Search.SearchELK
{
    public class SearchELKQueryHandler : IQueryHandler<SearchELKQuery, GetSearchResultDto>
    {
        private readonly IElasticSearchService<Domain.Aggregates.ArticleRoot.Article> _elasticSearchArticleService;
        private readonly IElasticSearchService<Domain.Aggregates.UserProfileRoot.UserProfile> _elasticSearchUserService;
        private readonly IMapper _mapper;

        public SearchELKQueryHandler(IMapper mapper, IElasticSearchService<Domain.Aggregates.ArticleRoot.Article> elasticSearchArticleService,
            IElasticSearchService<Domain.Aggregates.UserProfileRoot.UserProfile> elasticSearchUserService)
        {
            _elasticSearchArticleService = elasticSearchArticleService;
            _elasticSearchUserService = elasticSearchUserService;
            _mapper = mapper;
        }

        public async Task<GetSearchResultDto> Handle(SearchELKQuery request, CancellationToken cancellationToken)
        {
            var searchResults = new GetSearchResultDto();
            var artResponse = await _elasticSearchArticleService.SearchAsync("articles", request.SearchKey);
            var articleDtos = _mapper.Map<List<GetSearchArticleDto>>(artResponse);
            searchResults.Articles = articleDtos;

            var userResponse = await _elasticSearchUserService.SearchAsync("users", request.SearchKey);
            var userDtos = _mapper.Map<List<GetSearchUserProfileDto>>(userResponse);
            searchResults.Users = userDtos;

            return searchResults;

        }
    }
}
