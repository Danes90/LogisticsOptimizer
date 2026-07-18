using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Logistics.Infrastructure.Persistence;

public sealed class LogisticsDbContextFactory
    : IDesignTimeDbContextFactory<LogisticsDbContext>
{
    public LogisticsDbContext CreateDbContext(
        string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<LogisticsDbContext>();

        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5433;Database=logistics;Username=postgres;Password=postgres");

        return new LogisticsDbContext(
            optionsBuilder.Options);
    }
}