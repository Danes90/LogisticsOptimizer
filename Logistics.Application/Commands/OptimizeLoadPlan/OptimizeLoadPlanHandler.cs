using Logistics.Application.Interfaces;
using Logistics.Domain.Interfaces;

namespace Logistics.Application.Commands.OptimizeLoadPlan;

public sealed class OptimizeLoadPlanHandler
{
    private readonly ITruckRepository _truckRepository;
    private readonly IPalletRepository _palletRepository;
    private readonly ILoadOptimizer _optimizer;

    public OptimizeLoadPlanHandler(
        ITruckRepository truckRepository,
        IPalletRepository palletRepository,
        ILoadOptimizer optimizer)
    {
        _truckRepository = truckRepository;
        _palletRepository = palletRepository;
        _optimizer = optimizer;
    }

    public async Task<LoadPlanDto> Handle(
        OptimizeLoadPlanCommand command,
        CancellationToken cancellationToken)
    {
        var truck = await _truckRepository.GetByIdAsync(
            command.TruckId,
            cancellationToken);

        if (truck is null)
        {
            throw new InvalidOperationException(
                "Truck not found.");
        }

        var pallets =
            await _palletRepository.GetByIdsAsync(
                command.PalletIds,
                cancellationToken);

        var loadPlan =
            _optimizer.Optimize(
                truck,
                pallets);

        return new LoadPlanDto(
            loadPlan.TotalWeight,
            loadPlan.IsOverWeight,
            loadPlan.Placements
                .Select(x =>
                    new PlacementDto(
                        x.Pallet.Id,
                        x.Position.X,
                        x.Position.Y))
                .ToList());
    }
}