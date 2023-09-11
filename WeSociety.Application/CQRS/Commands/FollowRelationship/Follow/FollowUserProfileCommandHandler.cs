using MediatR;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.FollowRelationship.Follow
{
    public class FollowUserProfileCommandHandler : ICommandHandler<FollowUserProfileCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public FollowUserProfileCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(FollowUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _uow.UserProfiles.GetAsync(x => x.Id == request.FollowerId, cancellationToken);
            var newFollowRel = userProfile.Follow(request.FollowingId);
            return await Task.FromResult(Unit.Value);
        }
    }
}
