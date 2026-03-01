// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Configurations;

public class FormEligibilityConfiguration : IEntityTypeConfiguration<FormEligibility>
{
    public void Configure(EntityTypeBuilder<FormEligibility> builder)
    {
        builder.ToTable("FormEligibility");
        builder.HasKey(_ => new { _.Version, _.IndustrySpecialtyId, _.FormId });

        builder.Property(_ => _.Version).HasColumnType("varchar(10)");
        builder.Property(_ => _.Version).IsRequired(true);

        builder.Property(_ => _.IndustrySpecialtyId).IsRequired(true);
        builder.Property(_ => _.FormId).IsRequired(true);


        builder
            .HasOne<Form>()
            .WithMany()
            .HasForeignKey(e => new { e.Version, e.FormId })
            .IsRequired();

        builder
            .HasOne<IndustrySpecialty>()
            .WithMany()
            .HasForeignKey(e => new { e.Version, e.IndustrySpecialtyId })
            .IsRequired();
    }
}
