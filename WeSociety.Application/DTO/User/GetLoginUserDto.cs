using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.DTO.User
{
    public class GetLoginUserDto
    {
        public string Id { get; set; }
        public int UserProfileId { get; set; }
        public byte[] Image { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
