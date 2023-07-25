using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeSociety.Domain.AggregateRoots.Profile;
using WeSociety.Domain.AggregateRoots.Profile.Entities;

namespace WeSociety.Persistence.Configurations
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Content).IsRequired();  //will be html content
            builder.Property(x => x.Domain).IsRequired().HasMaxLength(256);

            builder.HasOne<Profile>(a => a.Profile)
                .WithMany(p => p.Articles)
                .HasForeignKey(a => a.ProfileId);


            builder.Property(x => x.IsActive).HasMaxLength(1).HasDefaultValueSql("1");
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("current_timestamp()");
            builder.Property(x => x.UpdatedAt).HasDefaultValueSql("current_timestamp() ON UPDATE current_timestamp()");
        }
    }
}
