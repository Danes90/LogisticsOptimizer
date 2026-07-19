using Logistics.Domain.Entities;

namespace Logistics.Application.Interfaces;

public interface IPalletRepository
{
    Task AddAsync(
        Pallet pallet,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Pallet>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Pallet>> GetByIdsAsync(
    IEnumerable<Guid> ids,
    CancellationToken cancellationToken = default);
}