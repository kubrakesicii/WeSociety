using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.Responses;
using WeSociety.Domain.AggregateRoots.Users;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.Article.GetAllByProfile
{
    public class GetAllArticlesByProfileQueryHandler : IQueryHandler<GetAllArticlesByProfileQuery, DataResponse<List<GetArticleDto>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authService;

        public GetAllArticlesByProfileQueryHandler(IUnitOfWork uow,IMapper mapper, IAuthenticationService authService)
        {
            _uow = uow;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<DataResponse<List<GetArticleDto>>> Handle(GetAllArticlesByProfileQuery request, CancellationToken cancellationToken)
        {
            int curProfileId = 0;
            if(_authService.IsAuthenticated)
            {
                var curUserId = "";
                curProfileId = (await _uow.UserProfiles.Get(x => x.UserId == curUserId)).Id;
            }

            var articles = await _uow.Articles.GetAllWithUserProfileByProfile(curProfileId, request.ProfileId);

            var articleDtos = _mapper.Map<List<GetArticleDto>>(articles);
            return new SuccessDataResponse<List<GetArticleDto>>(articleDtos);
        }
    }
}
