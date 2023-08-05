using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.DTO.UserProfile
{
    public class GetUserProfileDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingsCount { get; set; }
        public int IsFollowing { get; set; }
    }
}
