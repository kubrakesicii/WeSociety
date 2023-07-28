using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.FollowRelationship;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.FollowRelationship.GetAllFollowers
{
    public class GetAllFollowersQueryHandler : IQueryHandler<GetAllFollowersQuery, DataResponse<List<GetFollowerDto>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetAllFollowersQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<DataResponse<List<GetFollowerDto>>> Handle(GetAllFollowersQuery request, CancellationToken cancellationToken)
        {
            var followers = await _uow.FollowRelationships.GetAllFollowersByUserProfile(request.UserProfileId);
            var followersDto = _mapper.Map<List<GetFollowerDto>>(followers);
            return new SuccessDataResponse<List<GetFollowerDto>>(followersDto);
        }
    }
}
