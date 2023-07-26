using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeSociety.Domain.AggregateRoots.Profile;
using WeSociety.Domain.AggregateRoots.Profile.Entities;

namespace WeSociety.Persistence.Configurations
{
    public class FollowRelationshipConfig : IEntityTypeConfiguration<FollowRelationship>
    {
        public void Configure(EntityTypeBuilder<FollowRelationship> builder)
        {
            builder.HasOne<UserProfile>(followRel => followRel.Follower)
                .WithMany(p => p.Followers)
                .HasForeignKey(followRel => followRel.FollowerId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne<UserProfile>(followRel => followRel.Following)
                .WithMany(p => p.Followings)
                .HasForeignKey(followRel => followRel.FollowingId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Property(x => x.IsActive).HasMaxLength(1).HasDefaultValueSql("1");
            builder.Property(x => x.CreatedTime).ValueGeneratedOnAdd().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedTime).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
