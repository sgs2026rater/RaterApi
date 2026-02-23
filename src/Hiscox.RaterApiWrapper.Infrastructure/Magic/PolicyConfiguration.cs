// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApiWrapper.Infrastructure.Magic;

public class PolicyDetailsConfiguration : IEntityTypeConfiguration<PolicyDetails>
{
    public void Configure(EntityTypeBuilder<PolicyDetails> builder)
    {
        builder.ToTable("PolicyDetails");
        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version)
            .HasColumnType("varchar(10)")
            .IsRequired(true);

        builder.Property(_ => _.Id).IsRequired(true);

        builder.Property(_ => _.PUID)
            .HasColumnType("varchar(50)")
            .IsRequired(false);

        builder.Property(_ => _.PolicyNo)
            .HasColumnType("varchar(50)")
            .IsRequired(false);

        builder.Property(_ => _.NameDescr)
            .HasColumnType("varchar(200)")
            .IsRequired(false);

        builder.Property(_ => _.TimestampEffectivePolicy)
            .HasColumnType("datetime2")
            .IsRequired(true);

        builder.Property(_ => _.TimestampExpirationPolicy)
            .HasColumnType("datetime2")
            .IsRequired(true);

        builder.Property(_ => _.Zip)
            .HasColumnType("varchar(5)")
            .IsRequired(false);

        builder.Property(_ => _.Revenue)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        // EO Coverage
        builder.Property(_ => _.EO_GWP)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        builder.Property(_ => _.EO_Retention)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        builder.Property(_ => _.EO_OccLimit)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        builder.Property(_ => _.EO_AggLimit)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        // EO 2 Coverage
        builder.Property(_ => _.EO_2_GWP)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        builder.Property(_ => _.EO_2_Retention)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        builder.Property(_ => _.EO_2_OccLimit)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        builder.Property(_ => _.EO_2_AggLimit)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        // Cyber Coverage
        builder.Property(_ => _.Cyb_GWP)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        builder.Property(_ => _.Cyb_Retention)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        builder.Property(_ => _.Cyb_OccLimit)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        builder.Property(_ => _.Cyb_AggLimit)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        // GL Coverage
        builder.Property(_ => _.GL_GWP)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        builder.Property(_ => _.GL_Retention)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        builder.Property(_ => _.GL_OccLimit)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

        builder.Property(_ => _.GL_AggLimit)
            .HasColumnType("decimal(18, 2)")
            .IsRequired(true);

    }
}
