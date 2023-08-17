using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.DTO.Category;
using WeSociety.Application.DTO.UserProfile;

namespace WeSociety.Application.DTO.Article
{
    public class GetArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public string Content { get; set; }
        public byte[] MainImage { get; set; }
        public int ClapCount { get; set; }
        public int CommentCount { get; set; }
        public int IsPublished { get; set; }
        public GetUserProfileDto UserProfile { get; set; }
        public GetCategoryDto Category { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
