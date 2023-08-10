using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ArticleComment;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Queries.ArticleComment.GetAllByArticle
{
    public class GetAllArticleCommentsByArticleQuery : IQuery<DataResponse<List<GetArticleCommentDto>>>
    {
        public int ArticleId { get; set; }
    }
}
