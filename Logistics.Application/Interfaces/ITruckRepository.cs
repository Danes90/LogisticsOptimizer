namespace Logistics.Application.Interfaces;
using Logistics.Domain.Entities;

public interface ITruckRepository
{
    Task AddAsync(
        Truck truck,
        CancellationToken cancellationToken = default);

    Task<Truck?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Truck>> GetAllAsync(
    CancellationToken cancellationToken = default);
}