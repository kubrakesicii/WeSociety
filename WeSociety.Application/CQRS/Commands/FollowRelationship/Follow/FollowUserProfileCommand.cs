using MediatR;
using WeSociety.Application.CQRS.BaseModels;

namespace WeSociety.Application.CQRS.Commands.FollowRelationship.Follow
{
    public class FollowUserProfileCommand : ICommand<Unit>
    {
        public int FollowerId { get; set; }  //current user olacak
        public int FollowingId { get; set; }
    }
}
