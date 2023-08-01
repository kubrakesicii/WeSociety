using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Base;

namespace WeSociety.Domain.AggregateRoots.UserProfile.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
    }
}
