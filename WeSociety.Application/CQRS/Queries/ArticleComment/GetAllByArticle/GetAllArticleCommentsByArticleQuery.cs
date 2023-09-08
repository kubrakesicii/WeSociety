using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ArticleComment;

namespace WeSociety.Application.CQRS.Queries.ArticleComment.GetAllByArticle
{
    public class GetAllArticleCommentsByArticleQuery : IQuery<List<GetArticleCommentDto>>
    {
        public int ArticleId { get; set; }
    }
}
