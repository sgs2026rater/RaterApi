// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Configurations;

public class RetainedValueFactorMatrixConfiguration : IEntityTypeConfiguration<RetainedValueFactorMatrix>
{
    public void Configure(EntityTypeBuilder<RetainedValueFactorMatrix> builder)
    {
        builder.ToTable("RetainedValueFactorMatrix");

        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version)
            .HasColumnType("varchar(10)")
            .IsRequired(true);

        builder.Property(_ => _.Id)
            .IsRequired(true);

        builder.Property(_ => _.RetainedValue)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);

        builder.Property(_ => _.FactorEO)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);

        builder.Property(_ => _.FactorGL)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);

        builder.Property(_ => _.FactorCyber)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);
    }
}
