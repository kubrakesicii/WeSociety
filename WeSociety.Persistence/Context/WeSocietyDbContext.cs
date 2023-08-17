using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeSociety.Domain.Aggregates.ArticleRoot;
using WeSociety.Domain.Aggregates.ArticleRoot.Entities;
using WeSociety.Domain.Aggregates.CategoryRoot;
using WeSociety.Domain.Aggregates.ReadingListRoot;
using WeSociety.Domain.Aggregates.ReadingListRoot.Entities;
using WeSociety.Domain.Aggregates.UserProfileRoot;
using WeSociety.Domain.Aggregates.UserProfileRoot.Entities;
using WeSociety.Domain.Aggregates.UserRoot;
using WeSociety.Persistence.Configurations;

namespace WeSociety.Persistence.Context
{
    public class WeSocietyDbContext : IdentityDbContext<AppUser,IdentityRole, string>
    {

        public WeSocietyDbContext(DbContextOptions options) : base(options)
        {
        }
        public WeSocietyDbContext()
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FollowRelationship> FollowRelationships { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<ReadingList> ReadingLists { get; set; }
        public DbSet<ReadingListArticle> ReadingListArticles { get; set; }
        public DbSet<ArticleClap> ArticleClaps { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserProfileConfig());
            modelBuilder.ApplyConfiguration(new ArticleConfig());
            modelBuilder.ApplyConfiguration(new FollowRelationshipConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ArticleCommentConfig());
            modelBuilder.ApplyConfiguration(new ReadingListConfig());
            modelBuilder.ApplyConfiguration(new ReadingListArticleConfig());
            modelBuilder.ApplyConfiguration(new ArticleClapConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
