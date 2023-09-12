using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeSociety.Domain.Aggregates.UserProfileRoot;

namespace WeSociety.Persistence.Configurations
{
    public class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.Property(x => x.Bio).IsRequired(false).HasMaxLength(256);
            builder.Property(x => x.FullName).IsRequired(false).HasMaxLength(128);
            builder.Property(x => x.Image).IsRequired(false);

            builder.Property(x => x.Github).IsRequired(false).HasMaxLength(128);
            builder.Property(x => x.Linkedin).IsRequired(false).HasMaxLength(128);

            builder.HasOne(x => x.User).WithOne();

            builder.Property(x => x.IsActive).HasMaxLength(1).HasDefaultValue(true);
            builder.Property(x => x.CreatedTime).ValueGeneratedOnAdd().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedTime).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
