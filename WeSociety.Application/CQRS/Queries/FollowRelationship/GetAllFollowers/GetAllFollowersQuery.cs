using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.FollowRelationship;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Queries.FollowRelationship.GetAllFollowers
{
    public class GetAllFollowersQuery : IQuery<DataResponse<List<GetFollowerDto>>>
    {
        public int UserProfileId { get; set; }
    }
}
