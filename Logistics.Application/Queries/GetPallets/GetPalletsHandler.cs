using Logistics.Application.Interfaces;

namespace Logistics.Application.Queries.GetPallets;

public sealed class GetPalletsHandler
{
    private readonly IPalletRepository _repository;

    public GetPalletsHandler(
        IPalletRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<PalletDto>> Handle(
        GetPalletsQuery query,
        CancellationToken cancellationToken)
    {
        var pallets = await _repository.GetAllAsync(
            cancellationToken);

        return pallets
            .Select(x => new PalletDto(
                x.Id,
                x.Dimensions.Length,
                x.Dimensions.Width,
                x.Dimensions.Height,
                x.Weight))
            .ToList();
    }
}