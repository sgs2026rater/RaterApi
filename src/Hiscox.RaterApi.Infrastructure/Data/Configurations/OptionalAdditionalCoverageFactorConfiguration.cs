// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApi.Infrastructure.Data.Configurations;

public class OptionalAdditionalCoverageFactorConfiguration : IEntityTypeConfiguration<OptionalAdditionalCoverageFactor>
{
    public void Configure(EntityTypeBuilder<OptionalAdditionalCoverageFactor> builder)
    {
        builder.ToTable("OptionalAdditionalCoverageFactor");

        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version)
            .HasColumnType("varchar(10)")
            .IsRequired(true);

        builder.Property(_ => _.Id)
            .IsRequired(true);

        builder.Property(_ => _.Coverage)
            .HasColumnType("varchar(100)")
            .IsRequired(true);

        builder.Property(_ => _.YesFactor)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);

        builder.Property(_ => _.MinimalFactor)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);

        builder.Property(_ => _.MaterialFactor)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);
    }
}