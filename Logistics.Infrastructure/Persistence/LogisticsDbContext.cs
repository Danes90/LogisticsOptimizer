using Logistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Infrastructure.Persistence;

public sealed class LogisticsDbContext
    : DbContext
{
    public LogisticsDbContext(
        DbContextOptions<LogisticsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Pallet> Pallets =>
    Set<Pallet>();

    public DbSet<Truck> Trucks =>
        Set<Truck>();

    protected override void OnModelCreating(
    ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(LogisticsDbContext).Assembly);
    }
}