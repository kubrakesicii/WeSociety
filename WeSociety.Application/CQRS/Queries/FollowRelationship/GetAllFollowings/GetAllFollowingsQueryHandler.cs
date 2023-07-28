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
using WeSociety.Domain.Pagination;

namespace WeSociety.Application.CQRS.Queries.FollowRelationship.GetAllFollowings
{
    public class GetAllFollowingsQueryHandler : IQueryHandler<GetAllFollowingsQuery, DataResponse<PaginatedList<GetFollowingDto>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllFollowingsQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<DataResponse<PaginatedList<GetFollowingDto>>> Handle(GetAllFollowingsQuery request, CancellationToken cancellationToken)
        {
            var followings = await _uow.FollowRelationships.GetAllFollowingsByUserProfile(request.UserProfileId);
            var followingsDto = _mapper.Map<List<GetFollowingDto>>(followings);

            var paginatedRes = PaginatedResponse<GetFollowingDto>.Create(followingsDto, request.PageIndex, request.PageSize);
            return new SuccessDataResponse<PaginatedList<GetFollowingDto>>(paginatedRes);
        }
    }
}
