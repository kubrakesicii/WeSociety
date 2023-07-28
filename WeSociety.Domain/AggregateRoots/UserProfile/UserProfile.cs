using WeSociety.Domain.AggregateRoots.UserProfile.Entities;
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



        public UserProfile(byte[] image, string fullName, string bio, string userId)
        {
            Console.WriteLine("Created from user prof constructur");
            Image = image;
            FullName = fullName;
            Bio = bio;
            UserId = userId;
            Articles = new List<Article> { };
            Followings = new List<FollowRelationship> { };
            Followers = new List<FollowRelationship> { };
        }

        public void Update(byte[] image, string fullName, string bio)
        {
            Image = image;
            FullName = fullName;
            Bio = bio;
        }

        //Article bahavior methoda
        public Article AddArticle(string title, string content, int isPublished)
        {
            Article article = new Article(title, content, isPublished, Id);
            Articles.Add(article);
            return article;
        }

        public void DeleteArticle(Article article)
        {
            Articles.Remove(article);
        }


        // FOLLOW RELATION BEHAVIOR METHODS
        public FollowRelationship Follow(int followingId)
        {
            FollowRelationship followRel = new FollowRelationship(Id, followingId);
            Followings.Add(followRel);
            return followRel;
        }

        public void UnFollow(int followingId)
        {
            FollowRelationship followRel = new FollowRelationship(Id, followingId);
            if(followRel != null) Followings.Remove(followRel);
        }



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

    }
}
