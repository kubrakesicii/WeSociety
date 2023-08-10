using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.DTO.ReadingList
{
    public class GetReadingListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArticleCount { get; set; }
    }
}
