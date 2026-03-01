// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data;

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
        optionsBuilder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<IndustrySector>? IndustrySectors { get; set; } = null;
    public DbSet<IndustrySubSector>? IndustrySubSectors { get; set; } = null;
    public DbSet<IndustrySpecialty>? IndustrySpecialties { get; set; } = null;
    public DbSet<GeographicMod>? GeographicMods { get; set; } = null;
    public DbSet<PolicyDetails>? MagicPolicy { get; set; } = null;
    public DbSet<FormInfoLookup>? FormInfoLookups { get; set; } = null;
    public DbSet<Form>? Forms { get; set; } = null;
    public DbSet<FormEligibility>? FormEligibilities { get; set; } = null;

}
