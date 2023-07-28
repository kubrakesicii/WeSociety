using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.Responses;
using WeSociety.Domain.Pagination;

namespace WeSociety.Application.CQRS.Queries.Article.GetAll
{
    public class GetAllArticlesQuery : IQuery<DataResponse<PaginatedList<GetArticleDto>>>
    {
        public string? SearchKey { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
