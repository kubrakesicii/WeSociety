using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeSociety.Domain.AggregateRoots.Profile;

namespace WeSociety.Persistence.Configurations
{
    public class ProfileConfig : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.Property(x => x.Bio).IsRequired(false).HasMaxLength(256);
            builder.Property(x => x.Fullname).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Image).IsRequired(false);

            builder.Property(x => x.IsActive).HasMaxLength(1).HasDefaultValueSql("1");
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("current_timestamp()");
            builder.Property(x => x.UpdatedAt).HasDefaultValueSql("current_timestamp() ON UPDATE current_timestamp()");
        }
    }
}
