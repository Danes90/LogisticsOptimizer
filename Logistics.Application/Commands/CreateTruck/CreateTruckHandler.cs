namespace Logistics.Application.Commands.CreateTruck;
using Logistics.Application.Interfaces;
using Logistics.Domain.Entities;
using Logistics.Domain.ValueObjects;

public sealed class CreateTruckHandler
{
    private readonly ITruckRepository _repository;

    public CreateTruckHandler(
        ITruckRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        CreateTruckCommand command,
        CancellationToken cancellationToken)
    {
        var truck = new Truck(
            Guid.NewGuid(),
            new Dimensions(
                command.Length,
                command.Width,
                command.Height),
            command.MaxWeight);

        await _repository.AddAsync(
            truck,
            cancellationToken);
    }
}