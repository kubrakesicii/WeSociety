using WeSociety.Domain.Aggregates.ArticleRoot;
using WeSociety.Domain.Aggregates.ReadingListRoot.Entities;
using WeSociety.Domain.Aggregates.UserProfileRoot;
using WeSociety.Domain.Base;

namespace WeSociety.Domain.Aggregates.ReadingListRoot
{
    public class ReadingList : Entity
    {
        public string Name { get; private set; }

        //Bir kullanıcıya bağlı liste
        public int UserProfileId { get; private set; }
        public UserProfile UserProfile { get; private set; }

        //İçerisinde lis-article join listesi vardır
        public IList<ReadingListArticle> ReadingListArticles { get; private set; }


        public ReadingList(string name, int userProfileId)
        {
            Name = name;
            UserProfileId = userProfileId;
            ReadingListArticles = new List<ReadingListArticle>();
        }

        //// Add selected article to the Reading List of user
        //public void AddArticle(Article article)
        //{
        //    Articles.Add(article);
        //}

        //// Remove selected article from the Reading List of user
        //public void RemoveArticle(Article article)
        //{
        //    Articles.Remove(article);
        //}
    }
}
