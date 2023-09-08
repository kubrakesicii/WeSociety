using AutoMapper;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.Article.GetAllPopulars
{
    public class GetAllPopularArticlesQueryHandler : IQueryHandler<GetAllPopularArticlesQuery, List<GetArticleDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllPopularArticlesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetArticleDto>> Handle(GetAllPopularArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await _uow.Articles.GetAllPopulars(request.CategoryId);
            var articleDtos = _mapper.Map<List<GetArticleDto>>(articles);
            return articleDtos;
        }
    }
}
