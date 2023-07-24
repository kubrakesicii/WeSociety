using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Base;

namespace WeSociety.Domain.Entities.Profiles.FollowingProfiles
{
    public class FollowRelationship : BaseEntity
    {
        public int FollowerId { get; private set; }
        public Profile Follower { get; private set; }

        public int FollowingId { get; private set; }
        public Profile Following { get; private set; }

        public FollowRelationship(int followerId, int followingId)
        {
            FollowerId = followerId;
            FollowingId = followingId;
        }
    }
}
