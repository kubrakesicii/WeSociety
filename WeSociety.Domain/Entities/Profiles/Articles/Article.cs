using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Base;

namespace WeSociety.Domain.Entities.Profiles.Articles
{
    public class Article : BaseEntity
    {

        public string Title { get; private set; }
        public string Domain { get; private set; }
        public string Content { get; private set; }
        //public int IsPublished { get; private set; }

        public int ProfileId { get; private set; }
        public Profile Profile { get; private set; }


        public Article(string title, string domain, string content, int profileId)
        {
            Title = title;
            Domain = domain;
            Content = content;

            ProfileId = profileId == 0 ? throw new Exception("Profile must be exists") : profileId;
        }

    }
}
