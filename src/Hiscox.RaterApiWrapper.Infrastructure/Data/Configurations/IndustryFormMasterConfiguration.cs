// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Configurations;

public class IndustryFormMasterConfiguration : IEntityTypeConfiguration<IndustryFormMaster>
{
    public void Configure(EntityTypeBuilder<IndustryFormMaster> builder)
    {
        builder.ToTable("IndustryFormMaster");

        builder.HasKey(_ => new { _.Version, _.Id });

        builder.Property(_ => _.Version)
            .HasMaxLength(50)
            .HasColumnType("varchar(10)")
            .IsRequired();

        builder.Property(_ => _.FormName)
            .HasMaxLength(200)
            .IsRequired();
    }
}
