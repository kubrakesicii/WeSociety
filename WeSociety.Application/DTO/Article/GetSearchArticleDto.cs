using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.DTO.Article
{
    public class GetSearchArticleDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Domain { get; set; }
    }
}
