using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeSociety.Domain.Aggregates.ArticleRoot.Entities;

namespace WeSociety.Persistence.Configurations
{
    public class ArticleCommentConfig : IEntityTypeConfiguration<ArticleComment>
    {
        public void Configure(EntityTypeBuilder<ArticleComment> builder)
        {
            builder.Property(x => x.Text).IsRequired().HasMaxLength(200);
        }
    }
}
