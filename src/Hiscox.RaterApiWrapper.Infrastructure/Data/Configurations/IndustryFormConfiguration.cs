// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Configurations;

public class IndustryFormConfiguration : IEntityTypeConfiguration<IndustryForm>
{
    public void Configure(EntityTypeBuilder<IndustryForm> builder)
    {
        builder.ToTable("IndustryForm");

        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version)
            .HasMaxLength(50)
            .HasColumnType("varchar(10)")
            .IsRequired();

        builder.Property(_ => _.SpecialtyId)
            .IsRequired();

        builder.Property(_ => _.DefaultFormId)
            .IsRequired();

        builder
            .HasOne<IndustryFormMaster>()
            .WithMany()
            .HasForeignKey(e => new { e.Version, e.SpecialtyId })
            .IsRequired();
    }
}
