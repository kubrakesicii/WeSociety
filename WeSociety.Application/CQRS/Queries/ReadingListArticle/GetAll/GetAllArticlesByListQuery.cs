using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;

namespace WeSociety.Application.CQRS.Queries.ReadingListArticle.GetAll
{
    public class GetAllArticlesByListQuery : IQuery<List<GetArticleDto>>
    {
        public int ReadingListId { get; set; }
    }
}
