using Logistics.Application.Interfaces;
using Logistics.Domain.Entities;
using Logistics.Infrastructure.Persistence;

namespace Logistics.Infrastructure.Repositories;

public sealed class LoadPlanRepository
    : ILoadPlanRepository
{
    private readonly LogisticsDbContext _dbContext;

    public LoadPlanRepository(
        LogisticsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(
        LoadPlan loadPlan,
        CancellationToken cancellationToken = default)
    {
        //await _dbContext.LoadPlans.AddAsync(
          //  loadPlan,
            //cancellationToken);

        await _dbContext.SaveChangesAsync(
            cancellationToken);
    }
}