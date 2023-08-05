using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.CQRS.Commands.FollowRelationship.Follow;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.FollowRelationship.UnfollowUser
{
    public class UnfollowUserProfileCommandHandler : ICommandHandler<UnfollowUserProfileCommand, Response>
    {
        private readonly IUnitOfWork _uow;

        public UnfollowUserProfileCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(UnfollowUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _uow.UserProfiles.GetWithUserAsync(request.FollowerId);
            var removedFollowRel = userProfile.UnFollow(request.FollowingId);
            await _uow.FollowRelationships.Delete(removedFollowRel);
            await _uow.SaveChangesAsync();
            return new SuccessResponse();
        }
    }
}
