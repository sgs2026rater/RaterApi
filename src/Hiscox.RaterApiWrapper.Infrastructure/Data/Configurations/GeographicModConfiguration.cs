// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Configurations;

internal class GeographicModConfiguration : IEntityTypeConfiguration<GeographicMod>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<GeographicMod> builder)
    {
        builder.ToTable("GeographicMod");
        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version).HasColumnType("varchar(10)");
        builder.Property(_ => _.Version).IsRequired(true);

        builder.Property(_ => _.Id).IsRequired(true);

        builder.Property(_ => _.Zip).HasColumnType("varchar(5)");
        builder.Property(_ => _.Zip).IsRequired(true);

        builder.Property(_ => _.MsaNumber).HasColumnType("varchar(5)");
        builder.Property(_ => _.MsaNumber).IsRequired(true);

        builder.Property(_ => _.State).HasColumnType("varchar(2)");
        builder.Property(_ => _.State).IsRequired(true);

        builder.Property(_ => _.Fips).HasColumnType("varchar(2)");
        builder.Property(_ => _.Fips).IsRequired(true);

        builder.Property(_ => _.CountyNumber).HasColumnType("varchar(3)");
        builder.Property(_ => _.CountyNumber).IsRequired(true);

        builder.Property(_ => _.MsaName).HasColumnType("varchar(100)");
        builder.Property(_ => _.MsaName).IsRequired(true);

        builder.Property(_ => _.Name).HasColumnType("varchar(100)");
        builder.Property(_ => _.Name).IsRequired(true);

        builder.Property(_ => _.Tech).HasColumnType("decimal(20, 15)");
        builder.Property(_ => _.Tech).IsRequired(true);

        builder.Property(_ => _.Ahc).HasColumnType("decimal(20, 15)");
        builder.Property(_ => _.Ahc).IsRequired(true);

        builder.Property(_ => _.Mpl).HasColumnType("decimal(20, 15)");
        builder.Property(_ => _.Mpl).IsRequired(true);

        builder.Property(_ => _.AE).HasColumnType("decimal(20, 15)");
        builder.Property(_ => _.AE).IsRequired(true);

        builder.Property(_ => _.GlPremOps).HasColumnType("decimal(20, 15)");
        builder.Property(_ => _.GlPremOps).IsRequired(true);

        builder.Property(_ => _.Med).HasColumnType("decimal(20, 15)");
        builder.Property(_ => _.Med).IsRequired(true);

        builder.Property(_ => _.Cyber).HasColumnType("decimal(20, 15)");
        builder.Property(_ => _.Cyber).IsRequired(true);
    }
}