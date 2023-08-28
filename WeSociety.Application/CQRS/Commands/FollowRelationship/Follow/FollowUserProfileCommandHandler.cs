using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.FollowRelationship.Follow
{
    public class FollowUserProfileCommandHandler : ICommandHandler<FollowUserProfileCommand, Response>
    {
        private readonly IUnitOfWork _uow;

        public FollowUserProfileCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(FollowUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _uow.UserProfiles.Get(x => x.Id == request.FollowerId);
            var newFollowRel = userProfile.Follow(request.FollowingId);
            return new SuccessResponse();
        }
    }
}
