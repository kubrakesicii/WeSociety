using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Queries.Article.GetAllByProfile
{
    public class GetAllArticlesByProfileQuery : IQuery<DataResponse<List<GetArticleDto>>>
    {
        public int ProfileId { get; set; }
    }
}
