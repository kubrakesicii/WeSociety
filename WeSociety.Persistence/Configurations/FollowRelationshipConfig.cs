﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeSociety.Domain.Aggregates.UserProfileRoot.Entities;

namespace WeSociety.Persistence.Configurations
{
    public class FollowRelationshipConfig : IEntityTypeConfiguration<FollowRelationship>
    {
        public void Configure(EntityTypeBuilder<FollowRelationship> builder)
        {
            builder.HasOne(followRel => followRel.Follower)
                .WithMany(p => p.Followings)
                .HasForeignKey(followRel => followRel.FollowerId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(followRel => followRel.Following)
                .WithMany(p => p.Followers)
                .HasForeignKey(followRel => followRel.FollowingId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Property(x => x.IsActive).HasMaxLength(1).HasDefaultValue(true);
            builder.Property(x => x.CreatedTime).ValueGeneratedOnAdd().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedTime).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
