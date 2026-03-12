// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Configurations;

public class BusinessSizeDefinitionConfiguration : IEntityTypeConfiguration<BusinessSizeDefinition>
{
    public void Configure(EntityTypeBuilder<BusinessSizeDefinition> builder)
    {
        builder.ToTable("BusinessSizeDefinition");

        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version)
            .HasColumnType("varchar(10)")
            .IsRequired(true);

        builder.Property(_ => _.Id)
            .IsRequired(true);

        builder.Property(_ => _.CoverageType)
            .IsRequired(true);

        builder.Property(_ => _.Size)
            .IsRequired(true);

        builder.Property(_ => _.Revenue)
            .HasColumnType("decimal(18,4)")
            .IsRequired(true);
    }
}