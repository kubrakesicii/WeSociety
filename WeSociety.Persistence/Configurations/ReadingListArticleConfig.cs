using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Aggregates.ReadingListRoot;
using WeSociety.Domain.Aggregates.ReadingListRoot.Entities;

namespace WeSociety.Persistence.Configurations
{
    public class ReadingListArticleConfig : IEntityTypeConfiguration<ReadingListArticle>
    {
        public void Configure(EntityTypeBuilder<ReadingListArticle> builder)
        {
            builder.HasOne(la => la.Article)
                .WithMany(a => a.ReadingListArticles)
                .HasForeignKey(la => la.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(la => la.ReadingList)
                .WithMany(r => r.ReadingListArticles)
                .HasForeignKey(la => la.ReadingListId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.IsActive).HasMaxLength(1).HasDefaultValue(true);
            builder.Property(x => x.CreatedTime).ValueGeneratedOnAdd().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedTime).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETUTCDATE()");

        }
    }
}
