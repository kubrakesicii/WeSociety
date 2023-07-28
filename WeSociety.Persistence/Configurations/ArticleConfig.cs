using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeSociety.Domain.AggregateRoots.UserProfile;
using WeSociety.Domain.AggregateRoots.UserProfile.Entities;

namespace WeSociety.Persistence.Configurations
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Content).IsRequired();  //will be html content
            builder.Property(x => x.Domain).IsRequired().HasMaxLength(256);
            builder.Property(x => x.IsPublished).HasMaxLength(1).HasDefaultValueSql("1");

            builder.HasOne<UserProfile>(a => a.UserProfile)
                .WithMany(p => p.Articles)
                .HasForeignKey(a => a.UserProfileId);


            builder.Property(x => x.IsActive).HasMaxLength(1).HasDefaultValueSql("1");
            builder.Property(x => x.CreatedTime).ValueGeneratedOnAdd().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedTime).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
