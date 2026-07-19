using Logistics.Application.Interfaces;
using Logistics.Domain.Entities;
using Logistics.Domain.ValueObjects;

namespace Logistics.Application.Commands.CreatePallet;

public sealed class CreatePalletHandler
{
    private readonly IPalletRepository _repository;

    public CreatePalletHandler(
        IPalletRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        CreatePalletCommand command,
        CancellationToken cancellationToken)
    {
        var pallet = new Pallet(
            Guid.NewGuid(),
            new Dimensions(
                command.Length,
                command.Width,
                command.Height),
            command.Weight);

        await _repository.AddAsync(
            pallet,
            cancellationToken);
    }
}