using WeSociety.Application.CQRS.BaseModels;

namespace WeSociety.Application.CQRS.Queries.FollowRelationship.GetIsFollowing
{
    public class GetIsFollowingQuery : IQuery<bool>
    {
        public int FollowerId { get; set; }  //Will be auth user and sent auto from backend
        public int FollowingId { get; set; }
    }
}
