using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.AggregateRoots.Profile.Entities;
using WeSociety.Domain.AggregateRoots.Users;
using WeSociety.Domain.Base;

namespace WeSociety.Domain.AggregateRoots.Profile
{
    public class Profile : AggregateRoot
    {
        public byte[] Image { get; private set; }
        public string Fullname { get; private set; }
        public string Bio { get; private set; }

        public string UserId { get; private set; }
        public AppUser User { get; private set; }

        public ICollection<Article> Articles { get; private set; }

        public ICollection<FollowRelationship> FollowRelationships { get; private set; }


        public void AddFollowRelationship(int followerId, int followingId)
        {
            FollowRelationship followingProfile = new FollowRelationship(followerId, followingId);
            FollowRelationships.Add(followingProfile);
        }

        public void AddFollower(int followerId, int followingId)
        {
            FollowRelationship followingProfile = new FollowRelationship(followerId, Id);
            FollowRelationships.Add(followingProfile);
        }

        public void AddFollowing(int followerId, int followingId)
        {
            FollowRelationship followingProfile = new FollowRelationship(Id, followingId);
            FollowRelationships.Add(followingProfile);
        }

        public void RemoveFollowRelationship(int followerId, int followingId)
        {
            FollowRelationship followingProfile = new FollowRelationship(followerId, followingId);
            FollowRelationships.Remove(followingProfile);
        }


        //Behavior method
        public void AddArticle(string title, string domain, string content)
        {
            Article article = new Article(title, domain, content, Id);
            Articles.Add(article);
        }
    }
}
