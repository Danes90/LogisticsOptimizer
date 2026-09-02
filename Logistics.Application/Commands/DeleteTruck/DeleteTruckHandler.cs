using Logistics.Application.Exceptions;
using Logistics.Application.Interfaces;

namespace Logistics.Application.Commands.DeleteTruck;

public sealed class DeleteTruckHandler
{
    private readonly ITruckRepository _repository;

    public DeleteTruckHandler(
        ITruckRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        DeleteTruckCommand command,
        CancellationToken cancellationToken)
    {
        var truck =
            await _repository.GetByIdAsync(
                command.TruckId,
                cancellationToken);

        if (truck is null)
        {
            throw new TruckNotFoundException(
                command.TruckId);
        }

        await _repository.DeleteAsync(
            truck,
            cancellationToken);
    }
}