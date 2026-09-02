namespace Logistics.Application.Queries.GetTruckById;

using Logistics.Application.Exceptions;
using Logistics.Application.Interfaces;
using Logistics.Application.Queries.GetTrucks;

public sealed class GetTruckByIdHandler
{
    private readonly ITruckRepository _repository;

    public GetTruckByIdHandler(
        ITruckRepository repository)
    {
        _repository = repository;
    }

    public async Task<TruckDto> Handle(
        GetTruckByIdQuery query,
        CancellationToken cancellationToken)
    {
        var truck =
            await _repository.GetByIdAsync(
                query.TruckId,
                cancellationToken);

        if (truck is null)
        {
            throw new TruckNotFoundException(
                query.TruckId);
        }

        return new TruckDto(
            truck.Id,
            truck.Dimensions.Length,
            truck.Dimensions.Width,
            truck.Dimensions.Height,
            truck.MaxWeight);
    }
}