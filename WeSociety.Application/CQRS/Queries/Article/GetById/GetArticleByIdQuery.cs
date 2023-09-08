using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;

namespace WeSociety.Application.CQRS.Queries.Article.GetById
{
    public class GetArticleByIdQuery : IQuery<GetArticleDto>
    {
        public int Id { get; set; }
    }
}
