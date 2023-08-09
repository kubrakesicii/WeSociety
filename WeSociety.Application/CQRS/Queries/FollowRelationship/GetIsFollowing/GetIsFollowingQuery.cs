using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Queries.FollowRelationship.GetIsFollowing
{
    public class GetIsFollowingQuery : IQuery<DataResponse<bool>>
    {
        public int FollowerId { get; set; }  //Will be auth user and sent auto from backend
        public int FollowingId { get; set; }
    }
}
