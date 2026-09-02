using Logistics.Application.Exceptions;
using Logistics.Application.Interfaces;
using Logistics.Application.Queries.GetPallets;

namespace Logistics.Application.Queries.GetPalletById;

public sealed class GetPalletByIdHandler
{
    private readonly IPalletRepository _repository;

    public GetPalletByIdHandler(
        IPalletRepository repository)
    {
        _repository = repository;
    }

    public async Task<PalletDto> Handle(
        GetPalletByIdQuery query,
        CancellationToken cancellationToken)
    {
        var pallet =
            await _repository.GetByIdAsync(
                query.PalletId,
                cancellationToken);

        if (pallet is null)
        {
            throw new PalletNotFoundException();
        }

        return new PalletDto(
            pallet.Id,
            pallet.Dimensions.Length,
            pallet.Dimensions.Width,
            pallet.Dimensions.Height,
            pallet.Weight
            );
    }
}