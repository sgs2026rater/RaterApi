// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApi.Infrastructure.Data.Configurations;

public class OptCovTable1Configuration : IEntityTypeConfiguration<OptCovTable1>
{
    //This table corresponds to OptCov!(Columns B,E,Q and R) in the Rater Worksheet   
    public void Configure(EntityTypeBuilder<OptCovTable1> builder)
    {
        builder.ToTable("OptCovTable1");
        builder.HasKey(_ => new { _.Version, _.Id });
        builder.Property(_ => _.Version).HasColumnType("varchar(10)");
        builder.Property(_ => _.Version).IsRequired(true);

        builder.Property(_ => _.Id).IsRequired(true);

        builder.Property(_ => _.OptionalCoverage).HasColumnType("varchar(55)");
        builder.Property(_ => _.OptionalCoverage).IsRequired(true);

        builder.Property(_ => _.ApplicableToCoverageOrGTC).HasColumnType("varchar(15)");
        builder.Property(_ => _.ApplicableToCoverageOrGTC).IsRequired(true);

        builder.Property(_ => _.ApplicableToFormOrEndorsement).HasColumnType("varchar(25)");
        builder.Property(_ => _.ApplicableToFormOrEndorsement).IsRequired(true);

        builder.Property(_ => _.ENumber).HasColumnType("varchar(25)");
        builder.Property(_ => _.ENumber).IsRequired(true);
    }
}
