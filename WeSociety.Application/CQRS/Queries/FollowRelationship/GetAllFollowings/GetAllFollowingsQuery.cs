using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.FollowRelationship;
using WeSociety.Application.Responses;
using WeSociety.Domain.Pagination;

namespace WeSociety.Application.CQRS.Queries.FollowRelationship.GetAllFollowings
{
    public class GetAllFollowingsQuery : IQuery<DataResponse<PaginatedList<GetFollowingDto>>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int UserProfileId { get; set; }
    }
}
