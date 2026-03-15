// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApi.Infrastructure.Data.Configurations;

public class RatingFactorSectionEnabilityConfiguration : IEntityTypeConfiguration<RatingFactorSectionEnability>
{
    public void Configure(EntityTypeBuilder<RatingFactorSectionEnability> builder)
    {
        builder.ToTable("RatingFactorSectionEnabilities");

        builder.HasKey(x => new { x.Version, x.Id });

        builder.Property(x => x.Version)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.Section)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Size)
            .IsRequired();

        builder.Property(x => x.Enabled)
            .IsRequired();
    }
}
