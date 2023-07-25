using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Base;

namespace WeSociety.Domain.AggregateRoots.Profile.Entities
{
    public class ArticleComment : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
