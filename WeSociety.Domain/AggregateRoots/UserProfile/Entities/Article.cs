using WeSociety.Domain.Base;

namespace WeSociety.Domain.AggregateRoots.UserProfile.Entities
{
    public class Article : Entity
    {

        public string Title { get; private set; }
        public string Domain { get; private set; }
        public string Content { get; private set; }
        public int IsPublished { get; private set; }

        public int ProfileId { get; private set; }
        public UserProfile Profile { get; private set; }


        //public IList<ArticleComment> ArticleComments { get; set; }

        public Article(string title, string domain, string content, int profileId)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));
            Title = title;
            Domain = title.ToLower().Replace(" ", "-");
            Content = content;

            ProfileId = profileId == 0 ? throw new Exception("Profile must be exists") : profileId;
        }

    }
}
