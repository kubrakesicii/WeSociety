using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.DTO.ArticleClap
{
    public class GetClapUserDto
    {
        public int Count { get; set; }
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public string FullName { get; set; }
        public byte[] Image { get; set; }
        public string Bio { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
