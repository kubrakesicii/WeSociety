using WeSociety.Domain.Common;

namespace WeSociety.Domain.Aggregates.UserProfileRoot.Entities
{
    public class FollowRelationship : Entity
    {
        public int FollowerId { get; private set; }
        public UserProfile Follower { get; private set; }

        public int FollowingId { get; private set; }
        public UserProfile Following { get; private set; }

        public FollowRelationship(int followerId, int followingId)
        {
            FollowerId = followerId;
            FollowingId = followingId;
        }
    }
}
