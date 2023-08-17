using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Aggregates.ArticleRoot.Entities;
using WeSociety.Domain.Aggregates.ReadingListRoot;
using WeSociety.Domain.Aggregates.ReadingListRoot.Entities;

namespace WeSociety.Persistence.Configurations
{
    public class ArticleClapConfig : IEntityTypeConfiguration<ArticleClap>
    {
        public void Configure(EntityTypeBuilder<ArticleClap> builder)
        {
            builder.HasOne(cl => cl.Article)
                .WithMany(a => a.ArticleClaps)
                .HasForeignKey(cl => cl.ArticleId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(cl => cl.UserProfile)
                .WithMany(u => u.ArticleClaps)
                .HasForeignKey(cl => cl.UserProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.IsActive).HasMaxLength(1).HasDefaultValueSql("1");
            builder.Property(x => x.CreatedTime).ValueGeneratedOnAdd().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedTime).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETUTCDATE()");

        }
    }
}
