// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApi.Infrastructure.Data.Configurations;

public class RatingFactorMasterConfiguration : IEntityTypeConfiguration<RatingFactorMaster>
{
    public void Configure(EntityTypeBuilder<RatingFactorMaster> builder)
    {
        builder.ToTable("RatingFactorMaster");

        // Composite Primary Key
        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version)
               .HasColumnType("varchar(10)")
               .IsRequired(true);

        builder.Property(_ => _.Id)
               .IsRequired(true);

        builder.Property(_ => _.SectionId)
               .IsRequired(true);

        builder.Property(_ => _.QuestionId)
               .IsRequired(true);

        builder.Property(_ => _.Answer)
               .HasColumnType("bit")
               .HasDefaultValue(true)
               .IsRequired(true);

        builder.Property(_ => _.Factor)
               .HasColumnType("decimal(18,2)")
               .IsRequired(true);

        builder.Property(_ => _.Low)
               .HasColumnType("decimal(18,2)")
               .IsRequired(true);

        builder.Property(_ => _.High)
               .HasColumnType("decimal(18,2)")
               .IsRequired(true);

        builder.Property(_ => _.DegreeOfConcern)
               .HasColumnType("varchar(100)")
               .IsRequired(true);
    }
}
