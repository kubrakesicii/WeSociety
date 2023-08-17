using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Repositories;

namespace WeSociety.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserProfileRepository UserProfiles { get; }
        public IArticleRepository Articles { get; }
        public IFollowRelationshipRepository FollowRelationships { get; }
        public ICategoryRepository Categories { get; }
        public IArticleCommentRepository ArticleComments { get; }
        public IReadingListRepository ReadingLists { get; }
        public IReadingListArticleRepository ReadingListArticles { get; }
        public IArticleClapRepository ArticleClaps { get; }

        Task<int> SaveChangesAsync();
    }
}
