using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ReadingListArticle;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Queries.ReadingListArticle.GetIsSaved
{
    public class GetArticleIsSavedQuery : IQuery<DataResponse<GetIsSavedArticleDto>>
    {
        public int UserProfileId { get; set; }
        public int ArticleId { get; set; }
    }
}
