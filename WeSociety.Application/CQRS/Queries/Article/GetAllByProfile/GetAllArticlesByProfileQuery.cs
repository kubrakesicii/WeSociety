using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Domain.Pagination;

namespace WeSociety.Application.CQRS.Queries.Article.GetAllByProfile
{
    public class GetAllArticlesByProfileQuery : IQuery<PaginatedList<GetArticleDto>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int UserProfileId { get; set; }
    }
}
