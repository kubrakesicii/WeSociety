using AutoMapper;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.ReadingListArticle.GetAll
{
    public class GetAllArticlesByListQueryHandler : IQueryHandler<GetAllArticlesByListQuery, List<GetArticleDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllArticlesByListQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetArticleDto>> Handle(GetAllArticlesByListQuery request, CancellationToken cancellationToken)
        {
            var articles = await _uow.ReadingListArticles.GetAllArticlesOfReadingList(request.ReadingListId);
            var listDto = _mapper.Map<List<GetArticleDto>>(articles);
            return listDto;
        }
    }
}
