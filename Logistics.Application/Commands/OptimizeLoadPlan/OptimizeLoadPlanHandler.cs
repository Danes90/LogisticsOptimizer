using Logistics.Application.Exceptions;
using Logistics.Application.Interfaces;
using Logistics.Domain.Interfaces;

namespace Logistics.Application.Commands.OptimizeLoadPlan;

public sealed class OptimizeLoadPlanHandler
{
    private readonly ITruckRepository _truckRepository;
    private readonly IPalletRepository _palletRepository;
    private readonly ILoadOptimizer _optimizer;
    //private readonly ILoadPlanRepository _loadPlanRepository;

    public OptimizeLoadPlanHandler(
     ITruckRepository truckRepository,
     IPalletRepository palletRepository,
     ILoadOptimizer optimizer)
    {
        _truckRepository = truckRepository;
        _palletRepository = palletRepository;
        _optimizer = optimizer;
       // _loadPlanRepository = loadPlanRepository;
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
            throw new TruckNotFoundException(
                command.TruckId);
        }


    var pallets =
            await _palletRepository.GetByIdsAsync(
                command.PalletIds,
                cancellationToken);


        if (pallets.Count != command.PalletIds.Count)
        {
            throw new PalletNotFoundException();
        }


        var loadPlan =
            _optimizer.Optimize(
                truck,
                pallets);


        /*await _loadPlanRepository.AddAsync(
            loadPlan,
            cancellationToken);*/

        var placedCount = loadPlan.Placements.Count;
        var unplacedCount = pallets.Count - placedCount;
        var remainingCapacity =truck.MaxWeight -loadPlan.TotalWeight;
        var placedPalletIds =loadPlan.Placements.Select(x => x.Pallet.Id).ToHashSet();
        var unplacedPalletIds =pallets.Where(x => !placedPalletIds.Contains(x.Id)).Select(x => x.Id).ToList();

        return new LoadPlanDto(
            loadPlan.TotalWeight,
            remainingCapacity,
            loadPlan.IsOverWeight,
            placedCount,
            unplacedCount,
            unplacedPalletIds,
            loadPlan.Placements
                .Select(x =>
                    new PlacementDto(
                        x.Pallet.Id,
                        x.Position.X,
                        x.Position.Y,
                        x.Rotated))
                .ToList());
    }
}