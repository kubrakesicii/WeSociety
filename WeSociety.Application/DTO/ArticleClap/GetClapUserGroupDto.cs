using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.DTO.ArticleClap
{
    public class GetClapUserGroupDto
    {
        public int Count { get; set; }
        public Domain.Aggregates.UserProfileRoot.UserProfile UserProfile { get; set; }
    }
}
