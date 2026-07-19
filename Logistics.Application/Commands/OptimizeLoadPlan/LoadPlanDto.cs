namespace Logistics.Application.Commands.OptimizeLoadPlan;

public sealed record LoadPlanDto(
    int TotalWeight,
    bool IsOverWeight,
    IReadOnlyCollection<PlacementDto> Placements);