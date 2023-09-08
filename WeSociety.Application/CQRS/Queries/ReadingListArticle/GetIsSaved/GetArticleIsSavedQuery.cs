using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ReadingListArticle;

namespace WeSociety.Application.CQRS.Queries.ReadingListArticle.GetIsSaved
{
    public class GetArticleIsSavedQuery : IQuery<GetIsSavedArticleDto>
    {
        public int UserProfileId { get; set; }
        public int ArticleId { get; set; }
    }
}
