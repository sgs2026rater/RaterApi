// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApi.Infrastructure.Data.Configurations;

public class RevenueBaseRateConfiguration : IEntityTypeConfiguration<RevenueBaseRate>
{
    public void Configure(EntityTypeBuilder<RevenueBaseRate> builder)
    {
        builder.ToTable("RevenueBaseRate");

        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version)
            .HasColumnType("varchar(10)")
            .IsRequired(true);

        builder.Property(_ => _.Id)
            .IsRequired(true);

        builder.Property(_ => _.Revenue)
            .IsRequired(false);

        builder.Property(_ => _.BaseRateEO)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);

        builder.Property(_ => _.GLPremisesOperations1)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);

        builder.Property(_ => _.GLPremisesOperations2)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);

        builder.Property(_ => _.BaseRateCyber)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);

        builder.Property(_ => _.BaseRateTechEO)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);

        builder.Property(_ => _.BaseRateAHC)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);

        builder.Property(_ => _.BaseRateHomeHealthcare)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);

        builder.Property(_ => _.BaseRateSpas)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);
    }
}
