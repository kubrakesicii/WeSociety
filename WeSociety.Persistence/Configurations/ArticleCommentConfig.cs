using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeSociety.Domain.Aggregates.ArticleRoot.Entities;
using WeSociety.Domain.Aggregates.UserProfileRoot;

namespace WeSociety.Persistence.Configurations
{
    public class ArticleCommentConfig : IEntityTypeConfiguration<ArticleComment>
    {
        public void Configure(EntityTypeBuilder<ArticleComment> builder)
        {
            builder.Property(x => x.Text).IsRequired().HasMaxLength(200);

            builder.HasOne(cl => cl.Article)
              .WithMany(a => a.ArticleComments)
              .HasForeignKey(cl => cl.ArticleId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<UserProfile>(a => a.UserProfile)
                .WithMany(p => p.ArticleComments)
                .HasForeignKey(a => a.UserProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.IsActive).HasMaxLength(1).HasDefaultValue(true);
            builder.Property(x => x.CreatedTime).ValueGeneratedOnAdd().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedTime).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
