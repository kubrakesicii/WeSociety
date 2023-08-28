using WeSociety.Domain.Aggregates.ArticleRoot;
using WeSociety.Domain.Common;

namespace WeSociety.Domain.Aggregates.ReadingListRoot.Entities
{
    public class ReadingListArticle : Entity
    {
        public int ReadingListId { get; private set; }
        public ReadingList ReadingList { get; private set; }

        public int ArticleId { get; private set; }
        public Article Article { get; private set; }

        public ReadingListArticle(int readingListId, int articleId)
        {
            ReadingListId = readingListId;
            ArticleId = articleId;
        }
    }
}
