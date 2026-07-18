using Logistics.Application.Interfaces;
using Logistics.Domain.Entities;
using Logistics.Infrastructure.Persistence;

namespace Logistics.Infrastructure.Repositories;

public sealed class TruckRepository
    : ITruckRepository
{
    private readonly LogisticsDbContext _dbContext;

    public TruckRepository(
        LogisticsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(
        Truck truck,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Trucks.AddAsync(
            truck,
            cancellationToken);

        await _dbContext.SaveChangesAsync(
            cancellationToken);
    }

    public async Task<Truck?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Trucks.FindAsync(
            [id],
            cancellationToken);
    }
}