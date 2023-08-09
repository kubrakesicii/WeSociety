﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeSociety.Domain.Aggregates.ReadingListRoot;
using WeSociety.Domain.Aggregates.UserProfileRoot;

namespace WeSociety.Persistence.Configurations
{
    public class ReadingListConfig : IEntityTypeConfiguration<ReadingList>
    {
        public void Configure(EntityTypeBuilder<ReadingList> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);

            builder.HasOne<UserProfile>(r => r.UserProfile)
             .WithMany(p => p.ReadingLists)
             .HasForeignKey(r => r.UserProfileId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
