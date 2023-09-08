using MediatR;
using WeSociety.Application.CQRS.BaseModels;

namespace WeSociety.Application.CQRS.Commands.FollowRelationship.UnfollowUser
{
    public class UnfollowUserProfileCommand : ICommand<Unit>
    {
        public int FollowerId { get; set; }  //current user olacak
        public int FollowingId { get; set; }
    }
}
