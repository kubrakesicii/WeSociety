using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.UserProfile;
using WeSociety.Application.Interfaces;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.UserProfile.GetById
{
    public class GetUserProfileByIdQueryHandler : IQueryHandler<GetUserProfileByIdQuery, DataResponse<GetUserProfileDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IElasticSearchService<Domain.Aggregates.UserProfileRoot.UserProfile> _elasticSearchService;
        public GetUserProfileByIdQueryHandler(IUnitOfWork uow, IMapper mapper, IElasticSearchService<Domain.Aggregates.UserProfileRoot.UserProfile> elasticSearchService)
        {
            _uow = uow;
            _mapper = mapper;
            _elasticSearchService = elasticSearchService;
        }

        public async Task<DataResponse<GetUserProfileDto>> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var userProfile = await _uow.UserProfiles.GetWithUserAsync(request.Id);
            var userProfileDto = _mapper.Map<GetUserProfileDto>(userProfile);

            if (userProfileDto.Image.Length == 0) userProfileDto.Image = null;
            userProfileDto.FollowingsCount = userProfile.Followings.Count();
            userProfileDto.FollowersCount = userProfile.Followers.Count();

            //ELK INDEX
            await _elasticSearchService.CreateIndex("users", new Domain.Aggregates.UserProfileRoot.UserProfile(userProfile.FullName,userProfile.Bio,userProfile.UserId));

            return new SuccessDataResponse<GetUserProfileDto>(userProfileDto);
        }
    }
}
