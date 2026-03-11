// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Configurations;

public class IncludedCoverageEnhancementsConfiguration : IEntityTypeConfiguration<IncludedCoverageEnhancements>
{
    //This table corresponds to Other_lookup!(Table name - form_info_lkup) column AU in the Rater Worksheet   
    public void Configure(EntityTypeBuilder<IncludedCoverageEnhancements> builder)
    {
        builder.ToTable("IncludedCoverageEnhancements");
        builder.HasKey(_ => new { _.Version, _.Id });
        builder.Property(_ => _.Version).HasColumnType("varchar(10)");
        builder.Property(_ => _.Version).IsRequired(true);

        builder.Property(_ => _.Id).IsRequired(true);

        builder.Property(_ => _.Form).HasColumnType("varchar(55)");
        builder.Property(_ => _.Form).IsRequired(true);

        builder.Property(_ => _.LineOfBusiness).HasColumnType("varchar(55)");
        builder.Property(_ => _.LineOfBusiness).IsRequired(true);

        builder.Property(_ => _.ShortenedLineOfBusiness).HasColumnType("varchar(10)");
        builder.Property(_ => _.ShortenedLineOfBusiness).IsRequired(true);

        builder.Property(_ => _.ShortenedLineOfBusiness).HasColumnType("varchar(10)");
        builder.Property(_ => _.ShortenedLineOfBusiness).IsRequired(true);

        builder.Property(_ => _.ClaimsMode).HasColumnType("varchar(50)");
        builder.Property(_ => _.ClaimsMode).IsRequired(true);

        builder.Property(_ => _.CoverageEnhancements).HasColumnType("varchar(500)");
        builder.Property(_ => _.CoverageEnhancements).IsRequired(true);
    }
}
