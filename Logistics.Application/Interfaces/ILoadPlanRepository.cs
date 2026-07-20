using Logistics.Domain.Entities;

namespace Logistics.Application.Interfaces;

public interface ILoadPlanRepository
{
    Task AddAsync(
        LoadPlan loadPlan,
        CancellationToken cancellationToken = default);
}