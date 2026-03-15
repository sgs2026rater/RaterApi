// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApi.Infrastructure.Data.Configurations;

public class FormInfoLookupConfiguration : IEntityTypeConfiguration<FormInfoLookup>
{
    public void Configure(EntityTypeBuilder<FormInfoLookup> builder)
    {
        builder.ToTable("FormInfoLookups");

        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.FormName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(_ => _.LineOfBusiness)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(_ => _.LineOfBusinessShort)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(_ => _.DefaultClaimBasis)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(_ => _.CoverageEnhancements)
            .HasColumnType("varchar(1000)")
            .IsRequired();
    }
}
