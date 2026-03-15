// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApi.Infrastructure.Data.Configurations;

public class OptionalCoveragesTable2Configuration : IEntityTypeConfiguration<OptionalCoveragesTable2>   // Excel location - Optional_coverages!C276:R335
{
    public void Configure(EntityTypeBuilder<OptionalCoveragesTable2> builder)
    {
        builder.ToTable("OptionalCoveragesTable2");
        builder.HasKey(_ => new { _.Version, _.Id });
        builder.Property(_ => _.Version).HasColumnType("varchar(10)");
        builder.Property(_ => _.Version).IsRequired(true);

        builder.Property(_ => _.Id).IsRequired(true);

        builder.Property(_ => _.Coverage).HasColumnType("varchar(55)");
        builder.Property(_ => _.Coverage).IsRequired(true);

        builder.Property(_ => _.Differential).HasColumnType("varchar(20)");
        builder.Property(_ => _.Differential).IsRequired(true);
    }
}