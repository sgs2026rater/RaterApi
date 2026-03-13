// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApi.Infrastructure.Data.Configurations;

public class RetainedValueFactorConfiguration : IEntityTypeConfiguration<RetainedValueFactor>
{
    public void Configure(EntityTypeBuilder<RetainedValueFactor> builder)
    {
        builder.ToTable("RetainedValueFactor");

        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version)
            .HasColumnType("varchar(10)")
            .IsRequired(true);

        builder.Property(_ => _.Id)
            .IsRequired(true);

        builder.Property(_ => _.RetainedValuePercent)
            .HasColumnType("int")
            .IsRequired(true);

        builder.Property(_ => _.Factor)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);
    }
}
