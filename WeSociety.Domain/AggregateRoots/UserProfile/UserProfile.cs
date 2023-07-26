using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.AggregateRoots.Profile.Entities;
using WeSociety.Domain.AggregateRoots.Users;
using WeSociety.Domain.Base;

namespace WeSociety.Domain.AggregateRoots.UserProfile
{
    public class UserProfile : AggregateRoot
    {
        public byte[] Image { get; private set; }
        public string FullName { get; private set; }
        public string Bio { get; private set; }

        public string UserId { get; private set; }
        public AppUser User { get; private set; }

        public IList<Article> Articles { get; private set; }

        public IList<FollowRelationship> Followings { get; private set; }
        public IList<FollowRelationship> Followers { get; private set; }

        //public IList<FollowRelationship> FollowRelationships { get; private set; }


        // Bir profili takip etme işlemi
        //public void FollowProfile(int followingId)
        //{
        //    FollowRelationship followingProfile = new FollowRelationship(Id, followingId);
        //    FollowRelationships.Add(followingProfile);
        //}

        //public void UnfollowProfile(int followingId)
        //{
        //    FollowRelationship followingProfile = FollowRelationships.FirstOrDefault(x => x.FollowerId == Id);
        //    FollowRelationships.Add(followingProfile);
        //}


        //////////////
        //public void AddFollowRelationship(int followerId, int followingId)
        //{
        //    FollowRelationship followingProfile = new FollowRelationship(followerId, followingId);
        //    FollowRelationships.Add(followingProfile);
        //}
        //public void RemoveFollowRelationship(int followerId, int followingId)
        //{
        //    FollowRelationship followingProfile = new FollowRelationship(followerId, followingId);
        //    FollowRelationships.Remove(followingProfile);
        //}


        //Article bahavior methoda
        public void AddArticle(string title, string domain, string content)
        {
            Article article = new Article(title, domain, content, Id);
            Articles.Add(article);
        }

        public void RemoveArticle(Article artice)
        {
            Article article = Articles.FirstOrDefault(x => x.Id == artice.Id);
            Articles.Remove(article);
        }
    }
}
