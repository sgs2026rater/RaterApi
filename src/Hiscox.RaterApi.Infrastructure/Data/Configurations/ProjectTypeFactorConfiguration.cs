// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApi.Infrastructure.Data.Configurations;

public class ProjectTypeFactorConfiguration : IEntityTypeConfiguration<ProjectTypeFactor>
{
    public void Configure(EntityTypeBuilder<ProjectTypeFactor> builder)
    {
        builder.ToTable("ProjectTypeFactors");

        // Composite Primary Key
        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version)
               .HasColumnType("varchar(10)")
               .IsRequired(true);

        builder.Property(_ => _.Id)
               .IsRequired(true);

        builder.Property(_ => _.ProjectType).HasColumnType("varchar(100)");
        builder.Property(_ => _.ProjectType).IsRequired(true);

        builder.Property(_ => _.Factor)
               .HasColumnType("decimal(18,2)")
               .IsRequired(true);
    }
}
