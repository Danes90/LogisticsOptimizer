namespace Logistics.Application.Commands.OptimizeLoadPlan;

public sealed record LoadPlanDto(
    int TotalWeight,
    bool IsOverWeight,
    int PlacedCount,
    int UnplacedCount,
    IReadOnlyCollection<PlacementDto> Placements);