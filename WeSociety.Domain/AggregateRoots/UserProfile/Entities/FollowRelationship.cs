﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Base;

namespace WeSociety.Domain.AggregateRoots.UserProfile.Entities
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
