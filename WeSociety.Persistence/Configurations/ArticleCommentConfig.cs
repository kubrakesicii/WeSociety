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

            builder.HasOne<UserProfile>(a => a.UserProfile)
                .WithMany(p => p.ArticleComments)
                .HasForeignKey(a => a.UserProfileId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
