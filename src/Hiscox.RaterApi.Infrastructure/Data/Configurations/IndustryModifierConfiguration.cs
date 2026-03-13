// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApi.Infrastructure.Data.Configurations;

public class IndustryModifierConfiguration : IEntityTypeConfiguration<IndustryModifier>
{
    public void Configure(EntityTypeBuilder<IndustryModifier> builder)
    {
        builder.ToTable("IndustryModifier");

        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version)
            .HasColumnType("varchar(10)")
            .IsRequired(true);

        builder.Property(_ => _.Id)
            .IsRequired(true);

        builder.Property(_ => _.Specialty)
            .HasColumnType("varchar(100)")
            .IsRequired(true);

        builder.Property(_ => _.NAICSModifier)
            .HasColumnType("decimal(18,15)")
            .IsRequired(true);

        builder.Property(_ => _.EOMinimumPremium)
            .HasColumnType("decimal(18,2)")
            .IsRequired(true);
    }
}