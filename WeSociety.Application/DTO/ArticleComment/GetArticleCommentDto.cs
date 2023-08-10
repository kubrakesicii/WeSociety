using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.DTO.UserProfile;

namespace WeSociety.Application.DTO.ArticleComment
{
    public class GetArticleCommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public GetCommentUserProfileDto UserProfile { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
