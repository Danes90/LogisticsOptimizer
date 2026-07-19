namespace Logistics.Application.Commands.OptimizeLoadPlan;

public sealed record PlacementDto(
    Guid PalletId,
    int X,
    int Y);