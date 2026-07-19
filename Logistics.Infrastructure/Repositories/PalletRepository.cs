using Logistics.Application.Interfaces;
using Logistics.Domain.Entities;
using Logistics.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Infrastructure.Repositories;

public sealed class PalletRepository
    : IPalletRepository
{
    private readonly LogisticsDbContext _dbContext;

    public PalletRepository(
        LogisticsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(
        Pallet pallet,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Pallets.AddAsync(
            pallet,
            cancellationToken);

        await _dbContext.SaveChangesAsync(
            cancellationToken);
    }

    public async Task<IReadOnlyCollection<Pallet>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Pallets
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Pallet>> GetByIdsAsync(
    IEnumerable<Guid> ids,
    CancellationToken cancellationToken = default)
    {
        return await _dbContext.Pallets
            .Where(x => ids.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }
}