using WeSociety.Domain.Aggregates.ArticleRoot.Entities;
using WeSociety.Domain.Aggregates.CategoryRoot;
using WeSociety.Domain.Aggregates.UserProfileRoot;
using WeSociety.Domain.Base;

namespace WeSociety.Domain.Aggregates.ArticleRoot
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


        public IList<ArticleComment> ArticleComments { get; set; }

        public Article(string title, string content, int isPublished, int categoryId, byte[]? mainImage, int userProfileId)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));
            Title = title;
            Domain = title.ToLower().Replace(" ", "-");
            Content = content;
            IsPublished = isPublished;
            MainImage = mainImage;
            CategoryId = categoryId;
            UserProfileId = userProfileId == 0 ? throw new Exception("Profile must be exists") : userProfileId;
            ViewCount = 0;
        }

        public void Publish()
        {
            IsPublished = 1;
        }

        public void Update(string title, string content, int categoryId, byte[]? mainImage)
        {
            Title = title;
            Domain = title.ToLower().Replace(" ", "-");
            Content = content;
            MainImage = mainImage;
            CategoryId = categoryId;
        }

        public void IncreaseViewCount()
        {
            ViewCount = ViewCount + 1;
        }


        // Article comment 
        public void AddComment(int userProfileId, string text)
        {
            ArticleComment comment = new ArticleComment(userProfileId, text, Id);
            ArticleComments.Add(comment);
        }

    }
}
