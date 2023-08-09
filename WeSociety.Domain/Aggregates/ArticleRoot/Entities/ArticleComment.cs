using WeSociety.Domain.Aggregates.UserProfileRoot;
using WeSociety.Domain.Base;

namespace WeSociety.Domain.Aggregates.ArticleRoot.Entities
{
    public class ArticleComment : Entity
    {
        public string Text { get; private set; }

        public int UserProfileId { get; private set; }
        public UserProfile UserProfile { get; private set; }

        public int ArticleId { get; private set; }
        public Article Article { get; private set; }


        public ArticleComment(int userProfileId, string text, int articleId)
        {
            UserProfileId = userProfileId;
            Text = text;
            ArticleId = articleId;
        }
    }
}
