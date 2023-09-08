using AutoMapper;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Domain.Interfaces;
using WeSociety.Domain.Pagination;

namespace WeSociety.Application.CQRS.Queries.Article.GetAllByProfile
{
    public class GetAllArticlesByProfileQueryHandler : IQueryHandler<GetAllArticlesByProfileQuery, PaginatedList<GetArticleDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllArticlesByProfileQueryHandler(IUnitOfWork uow,IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PaginatedList<GetArticleDto>> Handle(GetAllArticlesByProfileQuery request, CancellationToken cancellationToken)
        {
            var articles = await _uow.Articles.GetAllWithUserProfileByProfile(1, request.UserProfileId);
            var articleDtos = _mapper.Map<List<GetArticleDto>>(articles);

            var paginatedRes = PaginatedResponse<GetArticleDto>.Create(articleDtos, request.PageIndex, request.PageSize);
            return paginatedRes;
        }
    }
}
