using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.DTO.User;

namespace WeSociety.Application.DTO.FollowRelationship
{
    public class GetFollowerDto
    {
        public int UserProfileId { get; set; }
        public string FullName { get; set; }
        public byte[] Image { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedTime { get; set; } 
    }
}
