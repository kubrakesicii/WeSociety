using WeSociety.Domain.Aggregates.ReadingListRoot.Entities;
using WeSociety.Domain.Aggregates.UserProfileRoot;
using WeSociety.Domain.Common;

namespace WeSociety.Domain.Aggregates.ReadingListRoot
{
    public class ReadingList : AggregateRoot
    {
        public string Name { get; private set; }
        //Bir kullanıcıya bağlı liste
        public int UserProfileId { get; private set; }
        public UserProfile UserProfile { get; private set; }

        //İçerisinde lis-article join listesi vardır
        public IList<ReadingListArticle> ReadingListArticles { get; private set; }


        public ReadingList(string name, int userProfileId)
        {
            if(name == null) throw new ArgumentNullException("name");
            Name = name;
            UserProfileId = userProfileId;
            ReadingListArticles = new List<ReadingListArticle>();
        }


        public void SaveArticle(int articleId)
        {
            ReadingListArticle listArticle = new ReadingListArticle(Id, articleId);
            ReadingListArticles.Add(listArticle);
        }

        public void UndoSaveArticle(ReadingListArticle listArticle)
        {
            ReadingListArticles.Remove(listArticle);
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
