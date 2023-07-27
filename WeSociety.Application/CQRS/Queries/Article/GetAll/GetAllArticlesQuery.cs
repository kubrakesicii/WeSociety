using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Queries.Article.GetAll
{
    public class GetAllArticlesQuery : IQuery<DataResponse<List<GetArticleDto>>>
    {
        public string? SearchKey { get; set; }
    }
}
