using Logistics.Application.Interfaces;

namespace Logistics.Application.Queries.GetTrucks;

public sealed class GetTrucksHandler
{
    private readonly ITruckRepository _repository;

    public GetTrucksHandler(
        ITruckRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<TruckDto>> Handle(
        GetTrucksQuery query,
        CancellationToken cancellationToken)
    {
        var trucks = await _repository.GetAllAsync(
            cancellationToken);

        return trucks
            .Select(x => new TruckDto(
                x.Id,
                x.Dimensions.Length,
                x.Dimensions.Width,
                x.Dimensions.Height,
                x.MaxWeight))
            .ToList();
    }
}