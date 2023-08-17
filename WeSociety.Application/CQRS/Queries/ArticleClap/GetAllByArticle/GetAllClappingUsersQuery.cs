using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ArticleClap;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Queries.ArticleClap.GetAllByArticle
{
    public class GetAllClappingUsersQuery : IQuery<DataResponse<List<GetClapUserDto>>>
    {
        public int ArticleId { get; set; }
    }
}
