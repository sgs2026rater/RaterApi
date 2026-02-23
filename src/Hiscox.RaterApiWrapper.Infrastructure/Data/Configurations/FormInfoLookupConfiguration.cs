// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Configurations;

public class FormInfoLookupConfiguration : IEntityTypeConfiguration<FormInfoLookup>
{
    public void Configure(EntityTypeBuilder<FormInfoLookup> builder)
    {
        builder.ToTable("FormInfoLookup");

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
            .HasColumnType("nvarchar(max)")
            .IsRequired();
    }
}
