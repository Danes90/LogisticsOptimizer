using Logistics.Application.Exceptions;
using Logistics.Application.Interfaces;

namespace Logistics.Application.Commands.DeletePallet;

public sealed class DeletePalletHandler
{
    private readonly IPalletRepository _repository;

    public DeletePalletHandler(
        IPalletRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        DeletePalletCommand command,
        CancellationToken cancellationToken)
    {
        var pallet =
            await _repository.GetByIdAsync(
                command.PalletId,
                cancellationToken);

        if (pallet is null)
        {
            throw new PalletNotFoundException();
        }

        await _repository.DeleteAsync(
            pallet,
            cancellationToken);
    }
}