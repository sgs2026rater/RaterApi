// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Configurations;

public class OptionalCoverageFactorsConfiguration : IEntityTypeConfiguration<OptionalCoverageFactor>
{
    public void Configure(EntityTypeBuilder<OptionalCoverageFactor> builder)
    {
        builder.ToTable("OptionalCoverageFactors");

        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version)
            .HasColumnType("varchar(10)")
            .IsRequired(true);

        builder.Property(_ => _.Id)
            .IsRequired(true);

        builder.Property(_ => _.PercentOfOccLimit)
            .HasColumnType("decimal(18,2)")
            .IsRequired(true);

        builder.Property(_ => _.Type)
            .HasColumnType("varchar(100)")
            .IsRequired(true);

        builder.Property(_ => _.Factor)
            .HasColumnType("decimal(18,2)")
            .IsRequired(true);
    }
}
