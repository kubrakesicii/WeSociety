using AutoMapper;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.UserProfile;
using WeSociety.Application.Interfaces;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.UserProfile.GetById
{
    public class GetUserProfileByIdQueryHandler : IQueryHandler<GetUserProfileByIdQuery, GetUserProfileDto>
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

        public async Task<GetUserProfileDto> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var userProfile = await _uow.UserProfiles.GetWithUserAsync(request.Id);
            var userProfileDto = _mapper.Map<GetUserProfileDto>(userProfile);         

            if (userProfileDto.Image.Length == 0) userProfileDto.Image = null;
            userProfileDto.FollowingsCount = userProfile.Followings.Count();
            userProfileDto.FollowersCount = userProfile.Followers.Count();

            return userProfileDto;
        }
    }
}
