using WeSociety.Domain.Base;

namespace WeSociety.Domain.AggregateRoots.UserProfile.Entities
{
    public class Article : Entity
    {

        public string Title { get; private set; }
        public string Domain { get; private set; }
        public string Content { get; private set; }
        public int IsPublished { get; private set; }

        public int ViewCount { get; set; }
        public int UserProfileId { get; private set; }
        public UserProfile UserProfile { get; private set; }

        public byte[] MainImage { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        //public IList<ArticleComment> ArticleComments { get; set; }

        public Article(string title, string content,int isPublished, byte[]? mainImage, int userProfileId)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));
            Title = title;
            Domain = title.ToLower().Replace(" ", "-");
            Content = content;
            IsPublished = isPublished;
            MainImage = mainImage;
            UserProfileId = userProfileId == 0 ? throw new Exception("Profile must be exists") : userProfileId;
            ViewCount = 0;
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

        public void IncreaseViewCount()
        {
            ViewCount =  ViewCount + 1;
        }

    }
}
