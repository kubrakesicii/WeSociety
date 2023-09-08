using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.FollowRelationship.GetIsFollowing
{
    public class GetIsFollowingQueryHandler : IQueryHandler<GetIsFollowingQuery, bool>
    {
        private readonly IUnitOfWork _uow;

        public GetIsFollowingQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(GetIsFollowingQuery request, CancellationToken cancellationToken)
        {
            return await _uow.FollowRelationships.IsFollowing(request.FollowerId, request.FollowingId);
        }
    }
}
