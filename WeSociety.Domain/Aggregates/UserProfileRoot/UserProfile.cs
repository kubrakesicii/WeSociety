using WeSociety.Domain.Aggregates.ArticleRoot;
using WeSociety.Domain.Aggregates.ArticleRoot.Entities;
using WeSociety.Domain.Aggregates.ReadingListRoot;
using WeSociety.Domain.Aggregates.UserProfileRoot.Entities;
using WeSociety.Domain.Aggregates.UserRoot;
using WeSociety.Domain.Base;

namespace WeSociety.Domain.Aggregates.UserProfileRoot
{
    public class UserProfile : AggregateRoot
    {

        public byte[] Image { get; private set; }
        public string FullName { get; private set; }
        public string Bio { get; private set; }

        public string UserId { get; private set; }
        public AppUser User { get; private set; }

        public IList<Article> Articles { get; private set; }

        // Takip ettiğim kullanıcılar - burada ben FolllowerId olurum
        public IList<FollowRelationship> Followings { get; private set; }

        // Beni takip eden kullanıcılar - burada ben FolllowingId olurum
        public IList<FollowRelationship> Followers { get; private set; }

        //Kullancıı birden fazla okuma listesi olabilir
        public IList<ReadingList> ReadingLists { get; set; }

        public IList<ArticleComment> ArticleComments { get; set; }



        public UserProfile(byte[]? image, string? fullName, string? bio, string userId)
        {
            Image = image;
            FullName = fullName;
            Bio = bio;
            UserId = userId;
            Articles = new List<Article> { };
            Followings = new List<FollowRelationship> { };
            Followers = new List<FollowRelationship> { };
            ReadingLists=new List<ReadingList> { };
        }

        public UserProfile(string userId)
        {
            Image = null;
            FullName = null;
            Bio = null;
            UserId = userId;
            Articles = new List<Article> { };
            Followings = new List<FollowRelationship> { };
            Followers = new List<FollowRelationship> { };
            ReadingLists = new List<ReadingList> { };
        }

        public void Update(byte[]? image, string fullName, string bio)
        {
            Image = image == null ? Image : image;
            FullName = fullName;
            Bio = bio;
        }

        //Article bahavior methoda
        public Article AddArticle(string title, string content, int isPublished,int categoryId, byte[]? mainImage)
        {
            Article article = new Article(title, content, isPublished,categoryId, mainImage,Id);
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

        public FollowRelationship UnFollow(int followingId)
        {
            FollowRelationship followRel = new FollowRelationship(Id, followingId);
            var removedFollowRel = Followings.FirstOrDefault(x => x.FollowingId == followingId);
            Followings.Remove(removedFollowRel);
            return removedFollowRel;
        }


        //Ben bu user'ı takip ediyor muyum?
        public bool IsFollowing(int userProfileId)
        {
            return Followings.Any(x => x.FollowingId == userProfileId);
        }

        //Create Reading List
        public void AddReadingList(string name)
        {
            ReadingList readingList = new ReadingList(name, this.Id);
            ReadingLists.Add(readingList);
        }

        public void RemoveReadingList(ReadingList readingList)
        {
            ReadingLists.Remove(readingList);
        }

    }
}
