using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using WeSociety.Domain.AggregateRoots.Profile;
using WeSociety.Domain.AggregateRoots.Profile.Entities;
using WeSociety.Domain.AggregateRoots.Users;

namespace WeSociety.Persistence.Configurations
{
    public class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.Property(x => x.Bio).IsRequired(false).HasMaxLength(256);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Image).IsRequired(false);

            builder.HasOne(x => x.User).WithOne();

            builder.Property(x => x.IsActive).HasMaxLength(1).HasDefaultValueSql("1");
            builder.Property(x => x.CreatedTime).ValueGeneratedOnAdd().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedTime).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
