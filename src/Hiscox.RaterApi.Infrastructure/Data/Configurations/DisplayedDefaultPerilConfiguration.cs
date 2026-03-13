// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApi.Infrastructure.Data.Configurations;

public class DisplayedDefaultPerilConfiguration : IEntityTypeConfiguration<DisplayedDefaultPeril>   // Excel location - OptCov!B67:H93
{
    public void Configure(EntityTypeBuilder<DisplayedDefaultPeril> builder)
    {
        builder.ToTable("DisplayedDefaultPerils");
        builder.HasKey(_ => new { _.Version, _.Id });
        builder.Property(_ => _.Version).HasColumnType("varchar(10)");
        builder.Property(_ => _.Version).IsRequired(true);

        builder.Property(_ => _.Id).IsRequired(true);

        builder.Property(_ => _.DefaultPeril).HasColumnType("varchar(55)");
        builder.Property(_ => _.DefaultPeril).IsRequired(true);

        builder.Property(_ => _.IsSwitchedOnByDefault).HasColumnType("bit");
        builder.Property(_ => _.IsSwitchedOnByDefault).IsRequired(true);

        builder.Property(_ => _.DefaultValueWhenSwitchedOn).HasColumnType("varchar(55)");
        builder.Property(_ => _.DefaultValueWhenSwitchedOn).IsRequired(true);

        builder.Property(_ => _.ApplicableTo).HasColumnType("varchar(55)");
        builder.Property(_ => _.ApplicableTo).IsRequired(true);
    }
}