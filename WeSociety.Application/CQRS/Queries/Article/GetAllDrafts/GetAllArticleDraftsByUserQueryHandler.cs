using AutoMapper;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Domain.Interfaces;
using WeSociety.Domain.Pagination;

namespace WeSociety.Application.CQRS.Queries.Article.GetAllDrafts
{
    public class GetAllArticleDraftsByUserQueryHandler : IQueryHandler<GetAllArticleDraftsByUserQuery, PaginatedList<GetArticleDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllArticleDraftsByUserQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PaginatedList<GetArticleDto>> Handle(GetAllArticleDraftsByUserQuery request, CancellationToken cancellationToken)
        {
            var articles = await _uow.Articles.GetAllDraftsWithUserProfileByProfile(request.UserProfileId);
            var articleDtos = _mapper.Map<List<GetArticleDto>>(articles);

            var paginatedRes = PaginatedResponse<GetArticleDto>.Create(articleDtos, request.PageIndex, request.PageSize);
            return paginatedRes;
        }
    }
}
