using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeSociety.Domain.AggregateRoots.UserProfile;
using WeSociety.Domain.AggregateRoots.UserProfile.Entities;
using WeSociety.Domain.AggregateRoots.Users;
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
        public DbSet<FollowRelationship> FollowRelationships { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserProfileConfig());
            modelBuilder.ApplyConfiguration(new ArticleConfig());
            modelBuilder.ApplyConfiguration(new FollowRelationshipConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
