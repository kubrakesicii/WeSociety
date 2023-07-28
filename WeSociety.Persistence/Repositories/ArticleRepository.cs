using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.AggregateRoots.UserProfile.Entities;
using WeSociety.Domain.Repositories;
using WeSociety.Persistence.Context;

namespace WeSociety.Persistence.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(WeSocietyDbContext context) : base(context)
        {
        }

        public async Task<List<Article>> GetAllWithUserProfile(string searchKey)
        {
            Expression<Func<Article, bool>> searchCond = x => true;
            if(searchKey != null) searchCond = x => x.Title.Contains(searchKey.ToUpper(new CultureInfo("tr-TR", false)))  || x.Content.Contains(searchKey.ToUpper(new CultureInfo("tr-TR", false)));
            return await _context.Articles.Include(x => x.UserProfile).Where(x => x.IsPublished == 1).Where(searchCond).ToListAsync();
        }

        public async Task<List<Article>> GetAllWithUserProfileByProfile(int currentUserId, int userProfileId)
        {
            Expression<Func<Article, bool>> publishCond = x => true;
            if (userProfileId != currentUserId) publishCond = x => x.IsPublished == 1;

            return await _context.Articles.Include(x => x.UserProfile).Where(publishCond).ToListAsync();
        }
    }
}
