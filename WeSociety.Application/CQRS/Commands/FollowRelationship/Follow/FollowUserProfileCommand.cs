using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Commands.FollowRelationship.Follow
{
    public class FollowUserProfileCommand : ICommand<Response>
    {
        public int FollowerId { get; set; }  //current user olacak
        public int FollowingId { get; set; }
    }
}
