namespace Logistics.Application.Commands.OptimizeLoadPlan;

public sealed record LoadPlanDto(
    int TotalWeight,
    int RemainingCapacity,
    bool IsOverWeight,
    int PlacedCount,
    int UnplacedCount,
    IReadOnlyCollection<Guid> UnplacedPalletIds,
    IReadOnlyCollection<PlacementDto> Placements);