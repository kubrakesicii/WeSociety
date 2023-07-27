using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.DTO.UserProfile;

namespace WeSociety.Application.DTO.Article
{
    public class GetArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public GetUserProfileDto Profile { get; set; }
    }
}
