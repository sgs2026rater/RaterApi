// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApi.Infrastructure.Data.Configurations;

public class OptionalCoverageTable1Configuration : IEntityTypeConfiguration<OptionalCoveragesTable1>
{
    //This table corresponds to Optional_Coverages!(3 columns from range C7 to M65) in the Rater Worksheet   
    public void Configure(EntityTypeBuilder<OptionalCoveragesTable1> builder)
    {
        builder.ToTable("OptionalCoveragesTable1");
        builder.HasKey(_ => new { _.Version, _.Id });
        builder.Property(_ => _.Version).HasColumnType("varchar(10)");
        builder.Property(_ => _.Version).IsRequired(true);

        builder.Property(_ => _.Id).IsRequired(true);

        builder.Property(_ => _.OptionalAdditionalCoverage).HasColumnType("varchar(55)");
        builder.Property(_ => _.OptionalAdditionalCoverage).IsRequired(true);

        builder.Property(_ => _.ValueOfInsurance).HasColumnType("varchar(55)");
        builder.Property(_ => _.ValueOfInsurance).IsRequired(true);

        builder.Property(_ => _.Premium).HasColumnType("varchar(55)");
        builder.Property(_ => _.Premium).IsRequired(true);
    }
}
