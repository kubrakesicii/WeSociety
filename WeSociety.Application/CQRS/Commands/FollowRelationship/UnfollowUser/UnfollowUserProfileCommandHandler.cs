using MediatR;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.FollowRelationship.UnfollowUser
{
    public class UnfollowUserProfileCommandHandler : ICommandHandler<UnfollowUserProfileCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public UnfollowUserProfileCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(UnfollowUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _uow.UserProfiles.GetWithUserAsync(request.FollowerId);
            var removedFollowRel = userProfile.UnFollow(request.FollowingId);
            await _uow.FollowRelationships.Delete(removedFollowRel);
            return await Task.FromResult(Unit.Value);
        }
    }
}
