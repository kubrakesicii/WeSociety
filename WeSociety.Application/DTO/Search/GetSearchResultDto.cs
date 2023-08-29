using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.DTO.UserProfile;

namespace WeSociety.Application.DTO.Search
{
    public class GetSearchResultDto
    {
        public List<GetSearchArticleDto> Articles { get; set; }
        public List<GetSearchUserProfileDto> Users { get; set; }
    }
}
