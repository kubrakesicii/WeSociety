using WeSociety.Domain.Base;

namespace WeSociety.Domain.AggregateRoots.UserProfile.Entities
{
    public class Article : Entity
    {

        public string Title { get; private set; }
        public string Domain { get; private set; }
        public string Content { get; private set; }
        public int IsPublished { get; private set; }

        public int UserProfileId { get; private set; }
        public UserProfile UserProfile { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        //public IList<ArticleComment> ArticleComments { get; set; }

        public Article(string title, string content,int isPublished, int userProfileId)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));
            Title = title;
            Domain = title.ToLower().Replace(" ", "-");
            Content = content;

            UserProfileId = userProfileId == 0 ? throw new Exception("Profile must be exists") : userProfileId;
        }

        public void Publish()
        {
            IsPublished = 1;
        }

        public void Update(string title, string content)
        {
            Title = title;
            Domain = title.ToLower().Replace(" ", "-");
            Content = content;
        }

    }
}
