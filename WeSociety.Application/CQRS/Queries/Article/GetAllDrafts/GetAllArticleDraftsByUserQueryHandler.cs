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
using WeSociety.Domain.Pagination;

namespace WeSociety.Application.CQRS.Queries.Article.GetAllDrafts
{
    public class GetAllArticleDraftsByUserQueryHandler : IQueryHandler<GetAllArticleDraftsByUserQuery, DataResponse<PaginatedList<GetArticleDto>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authService;

        public GetAllArticleDraftsByUserQueryHandler(IUnitOfWork uow, IMapper mapper, IAuthenticationService authService)
        {
            _uow = uow;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<DataResponse<PaginatedList<GetArticleDto>>> Handle(GetAllArticleDraftsByUserQuery request, CancellationToken cancellationToken)
        {
            int curProfileId = 0;
            if (_authService.IsAuthenticated)
            {
                var curUserId = "";
                curProfileId = (await _uow.UserProfiles.Get(x => x.UserId == curUserId)).Id;
            }

            var articles = await _uow.Articles.GetAllDraftsWithUserProfileByProfile(request.UserProfileId);
            var articleDtos = _mapper.Map<List<GetArticleDto>>(articles);

            var paginatedRes = PaginatedResponse<GetArticleDto>.Create(articleDtos, request.PageIndex, request.PageSize);
            return new SuccessDataResponse<PaginatedList<GetArticleDto>>(paginatedRes);
        }
    }
}
