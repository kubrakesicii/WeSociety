using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Queries.ReadingListArticle.GetAll
{
    public class GetAllArticlesByListQuery : IQuery<DataResponse<List<GetArticleDto>>>
    {
        public int ReadingListId { get; set; }
    }
}
