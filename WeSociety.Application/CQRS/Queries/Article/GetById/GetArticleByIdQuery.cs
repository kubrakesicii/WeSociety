using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Queries.Article.GetById
{
    public class GetArticleByIdQuery : IQuery<DataResponse<GetArticleDto>>
    {
        public int Id { get; set; }
    }
}
