// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Configurations;

public class IndustrySectorConfiguration : IEntityTypeConfiguration<IndustrySector>
{
    public void Configure(EntityTypeBuilder<IndustrySector> builder)
    {
        builder.ToTable("IndustrySector");
        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version).HasColumnType("varchar(10)");
        builder.Property(_ => _.Version).IsRequired(true);

        builder.Property(_ => _.Id).IsRequired(true);

        builder.Property(_ => _.Name).HasColumnType("varchar(100)");
        builder.Property(_ => _.Name).IsRequired(true);

    }
}
