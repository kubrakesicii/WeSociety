using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.FollowRelationship.GetIsFollowing
{
    public class GetIsFollowingQueryHandler : IQueryHandler<GetIsFollowingQuery, DataResponse<bool>>
    {
        private readonly IUnitOfWork _uow;

        public GetIsFollowingQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<DataResponse<bool>> Handle(GetIsFollowingQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResponse<bool>(await _uow.FollowRelationships.IsFollowing(request.FollowerId, request.FollowingId));
        }
    }
}
