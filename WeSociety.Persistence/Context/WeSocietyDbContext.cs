using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.AggregateRoots.Users;
using WeSociety.Persistence.Configurations;

namespace WeSociety.Persistence.Context
{
    public class WeSocietyDbContext : IdentityDbContext<AppUser>
    {

        public WeSocietyDbContext(DbContextOptions options) : base(options)
        {
        }
        public WeSocietyDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfileConfig());
            modelBuilder.ApplyConfiguration(new ArticleConfig());
            modelBuilder.ApplyConfiguration(new FollowRelationhhipConfig());
        }
    }
}
