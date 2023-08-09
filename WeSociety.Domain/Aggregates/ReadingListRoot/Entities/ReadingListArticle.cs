using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Aggregates.ArticleRoot;
using WeSociety.Domain.Base;

namespace WeSociety.Domain.Aggregates.ReadingListRoot.Entities
{
    public class ReadingListArticle : Entity
    {
        public int ReadingListId { get; set; }
        public ReadingList ReadingList { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
