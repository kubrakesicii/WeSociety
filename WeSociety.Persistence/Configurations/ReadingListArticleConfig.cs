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
            builder.HasKey(listArt => new { listArt.ArticleId, listArt.ReadingListId });

            builder.HasOne(la => la.Article)
                .WithMany(a => a.ReadingListArticles)
                .HasForeignKey(la => la.ArticleId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(la => la.ReadingList)
                .WithMany(r => r.ReadingListArticles)
                .HasForeignKey(la => la.ReadingListId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
