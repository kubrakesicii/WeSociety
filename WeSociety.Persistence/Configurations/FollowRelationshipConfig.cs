using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeSociety.Domain.AggregateRoots.Profile;
using WeSociety.Domain.AggregateRoots.Profile.Entities;

namespace WeSociety.Persistence.Configurations
{
    public class FollowRelationhhipConfig : IEntityTypeConfiguration<FollowRelationship>
    {
        public void Configure(EntityTypeBuilder<FollowRelationship> builder)
        {
            builder.HasKey(fr => new { fr.FollowerId, fr.FollowingId });

            builder.HasOne<Profile>(followRel => followRel.Follower)
                .WithMany(p => p.FollowRelationships)
                .HasForeignKey(followRel => followRel.FollowerId);


            builder.HasOne<Profile>(followRel => followRel.Following)
                .WithMany(p => p.FollowRelationships)
                .HasForeignKey(followRel => followRel.FollowingId);


            builder.Property(x => x.IsActive).HasMaxLength(1).HasDefaultValueSql("1");
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("current_timestamp()");
            builder.Property(x => x.UpdatedAt).HasDefaultValueSql("current_timestamp() ON UPDATE current_timestamp()");
        }
    }
}
