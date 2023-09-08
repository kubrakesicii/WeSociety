using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Domain.Pagination;

namespace WeSociety.Application.CQRS.Queries.Article.GetAll
{
    public class GetAllArticlesQuery : IQuery<PaginatedList<GetArticleDto>>
    {
        public string? SearchKey { get; set; }
        public int CategoryId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
