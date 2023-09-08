using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;

namespace WeSociety.Application.CQRS.Queries.Article.GetAllPopulars
{
    public class GetAllPopularArticlesQuery : IQuery<List<GetArticleDto>>
    {
        public int CategoryId { get; set; }
    }
}
