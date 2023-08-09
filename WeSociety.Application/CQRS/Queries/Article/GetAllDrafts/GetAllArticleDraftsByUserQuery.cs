using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.Responses;
using WeSociety.Domain.Pagination;

namespace WeSociety.Application.CQRS.Queries.Article.GetAllDrafts
{
    public class GetAllArticleDraftsByUserQuery : IQuery<DataResponse<PaginatedList<GetArticleDto>>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int UserProfileId { get; set; }  // Current userdan alınacaks
    }
}
