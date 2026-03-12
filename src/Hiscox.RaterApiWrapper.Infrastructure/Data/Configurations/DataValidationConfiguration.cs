// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Configurations;

public class DataValidationConfiguration : IEntityTypeConfiguration<DataValidation> // Excel location - OptCov!AW7:AX58
{
    public void Configure(EntityTypeBuilder<DataValidation> builder)
    {
        builder.ToTable("DataValidations");
        builder.HasKey(_ => new { _.Version, _.Id });
        builder.Property(_ => _.Version).HasColumnType("varchar(10)");
        builder.Property(_ => _.Version).IsRequired(true);

        builder.Property(_ => _.Id).IsRequired(true);

        builder.Property(_ => _.Peril).HasColumnType("varchar(55)");
        builder.Property(_ => _.Peril).IsRequired(true);

        builder.Property(_ => _.DataValidationToUse).HasColumnType("varchar(10)");
        builder.Property(_ => _.DataValidationToUse).IsRequired(true);
    }
}