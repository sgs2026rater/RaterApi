// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hiscox.RaterApi.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
        // Apply snake_case globally
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(ToSnakeCase(entity.GetTableName()));
            foreach (var property in entity.GetProperties())
                property.SetColumnName(ToSnakeCase(property.GetColumnName()));
            foreach (var key in entity.GetKeys())
                key.SetName(ToSnakeCase(key.GetName()));
            foreach (var fk in entity.GetForeignKeys())
                fk.SetConstraintName(ToSnakeCase(fk.GetConstraintName()));
            foreach (var index in entity.GetIndexes())
                index.SetDatabaseName(ToSnakeCase(index.GetDatabaseName()));
        }

    }

    public DbSet<IndustrySector>? IndustrySectors { get; set; } = null;
    public DbSet<IndustrySubSector>? IndustrySubSectors { get; set; } = null;
    public DbSet<IndustrySpecialty>? IndustrySpecialties { get; set; } = null;
    public DbSet<GeographicMod>? GeographicMods { get; set; } = null;
    public DbSet<PolicyDetails>? MagicPolicy { get; set; } = null;
    public DbSet<FormInfoLookup>? FormInfoLookups { get; set; } = null;
    public DbSet<Form>? Forms { get; set; } = null;
    public DbSet<RatingFactorMaster>? RatingFactor { get; set; } = null;
    public DbSet<FormEligibility>? FormEligibilities { get; set; } = null;
    public DbSet<LimitRetentionFactor>? LimitRetentionFactors { get; set; } = null;
    public DbSet<ProjectTypeFactor>? ProjectTypeFactors { get; set; } = null;
    public DbSet<RetainedValueFactor>? RetainedValueFactors { get; set; } = null;
    public DbSet<RetainedValueFactorMatrix>? RetainedValueFactorMatrixs { get; set; } = null;
    public DbSet<RevenueBaseRate>? RevenueBaseRates { get; set; } = null;
    public DbSet<OptionalAdditionalCoverageFactor>? OptionalAdditionalCoverageFactors { get; set; } = null;
    public DbSet<RatingFactorSectionEnability>? RatingFactorSectionEnabilities { get; set; } = null;
    public DbSet<IndustryModifier>? IndustryModifiers { get; set; } = null;

    #region Coverage (Tab 6)

    public DbSet<IncludedCoverageEnhancements>? IncludedCoverageEnhancements { get; set; } = null;
    public DbSet<OptCovTable1>? OptCovTables { get; set; } = null;
    public DbSet<OptionalCoverageFactor>? OptionalCoverageFactors { get; set; } = null;

    public DbSet<OptionalCoveragesTable1>? OptionalCoveragesTables { get; set; } = null;
    public DbSet<DisplayedDefaultPeril>? DisplayedDefaultPerils { get; set; } = null;
    public DbSet<DataValidation>? DataValidations { get; set; } = null;
    public DbSet<OptionalCoveragesTable2>? OptionalCoveragesTable2s { get; set; } = null;
    public DbSet<BusinessSizeDefinition>? BusinessSizeDefinitions { get; set; } = null;

    #endregion Coverage (Tab 6)


    private static string ToSnakeCase(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        var result = new System.Text.StringBuilder();
        result.Append(char.ToLowerInvariant(input[0]));
        for (int i = 1; i < input.Length; i++)
        {
            char c = input[i];
            if (char.IsUpper(c))
            {
                if (char.IsLower(input[i - 1]) || (i < input.Length - 1 && char.IsLower(input[i + 1])))
                    result.Append('_');
                result.Append(char.ToLowerInvariant(c));
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }

}