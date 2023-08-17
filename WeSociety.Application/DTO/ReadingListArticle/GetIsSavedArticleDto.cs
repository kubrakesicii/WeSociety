using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.DTO.ReadingListArticle
{
    public class GetIsSavedArticleDto
    {
        public int Id { get; set; }
        public bool IsSaved { get; set; }
    }
}
