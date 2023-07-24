using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Base;
using WeSociety.Domain.Entities.Profiles.Articles;
using WeSociety.Domain.Entities.Profiles.FollowingProfiles;
using WeSociety.Domain.Entities.Users;

namespace WeSociety.Domain.Entities.Profiles
{
    public class Profile : BaseEntity
    {
        public byte[] Image { get; private set; }
        public string Fullname { get; private set; }
        public string Bio { get; private set; }

        public string UserId { get; private set; }
        public AppUser User { get; private set; }

        public ICollection<Article> Articles { get; private set; }

        public ICollection<FollowRelationship> FollowRelationships { get; private set; }


        public void FollowProfile(int followerId, int followingId)
        {
            FollowRelationship followingProfile = new FollowRelationship(followerId, followingId);
            FollowRelationships.Add(followingProfile);
        }

        public void AddArticle(string title, string domain, string content) {
            Article article = new Article(title, domain, content, this.Id);
            Articles.Add(article);
        }
    }
}
