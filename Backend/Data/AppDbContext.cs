using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<PremiumMethod> PremiumMethods => Set<PremiumMethod>();
    public DbSet<Metric> Metrics => Set<Metric>();
    public DbSet<MetricField> MetricFields => Set<MetricField>();
    public DbSet<Import> Imports => Set<Import>();
    public DbSet<ImportSchema> ImportSchemas => Set<ImportSchema>();
    public DbSet<ImportSchemaField> ImportSchemaFields => Set<ImportSchemaField>();
    public DbSet<ImportRow> ImportRows => Set<ImportRow>();
    public DbSet<ImportValue> ImportValues => Set<ImportValue>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PremiumMethod>()
            .HasIndex(x => x.MethodNumber)
            .IsUnique();

        modelBuilder.Entity<Metric>()
            .HasIndex(x => x.PremiumMethodId);

        modelBuilder.Entity<MetricField>()
            .HasIndex(x => new { x.MetricId, x.Name })
            .IsUnique();

        modelBuilder.Entity<Import>()
            .HasIndex(x => new { x.MetricId, x.Year, x.Period });

        modelBuilder.Entity<ImportRow>()
            .HasIndex(x => new { x.ImportId, x.RowNumber })
            .IsUnique();

        modelBuilder.Entity<ImportValue>()
            .HasIndex(x => new { x.ImportRowId, x.MetricFieldId })
            .IsUnique();

        modelBuilder.Entity<PremiumMethod>()
            .HasMany(x => x.Metrics)
            .WithOne(x => x.PremiumMethod)
            .HasForeignKey(x => x.PremiumMethodId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Metric>()
            .HasMany(x => x.Fields)
            .WithOne(x => x.Metric)
            .HasForeignKey(x => x.MetricId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Metric>()
            .HasMany(x => x.Imports)
            .WithOne(x => x.Metric)
            .HasForeignKey(x => x.MetricId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Import>()
            .HasMany(x => x.Rows)
            .WithOne(x => x.Import)
            .HasForeignKey(x => x.ImportId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ImportRow>()
            .HasMany(x => x.Values)
            .WithOne(x => x.ImportRow)
            .HasForeignKey(x => x.ImportRowId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
