// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApi.Infrastructure.Data.Configurations;

public class LimitRetentionFactorConfiguration : IEntityTypeConfiguration<LimitRetentionFactor>
{
    public void Configure(EntityTypeBuilder<LimitRetentionFactor> builder)
    {
        builder.ToTable("LimitRetentionFactor");

        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version)
            .HasColumnType("varchar(10)")
            .IsRequired(true);

        builder.Property(_ => _.Id)
            .IsRequired(true);

        builder.Property(_ => _.LimitRetentionOption)
            .IsRequired(false);

        builder.Property(_ => _.EoLow)
            .HasColumnType("decimal(18,4)")
            .IsRequired(false);

        builder.Property(_ => _.EoMedium)
            .HasColumnType("decimal(18,4)")
            .IsRequired(false);

        builder.Property(_ => _.EoHigh)
            .HasColumnType("decimal(18,4)")
            .IsRequired(false);

        builder.Property(_ => _.FactorGlPremisesOperations)
            .HasColumnType("decimal(18,4)")
            .IsRequired(false);

        builder.Property(_ => _.FactorGlProductsOperations)
            .HasColumnType("decimal(18,4)")
            .IsRequired(false);

        builder.Property(_ => _.FactorCyber)
            .HasColumnType("decimal(18,4)")
            .IsRequired(false);
    }
}
