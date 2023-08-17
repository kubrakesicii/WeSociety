using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Aggregates.UserProfileRoot;
using WeSociety.Domain.Base;

namespace WeSociety.Domain.Aggregates.ArticleRoot.Entities
{
    public class ArticleClap : Entity
    {
        public int UserProfileId { get; private set; }
        public UserProfile UserProfile { get; private set; }

        public int ArticleId { get; private set; }
        public Article Article { get; private set; }


        public ArticleClap(int userProfileId,int articleId)
        {
            UserProfileId = userProfileId;
            ArticleId = articleId;
        }
    }
}
