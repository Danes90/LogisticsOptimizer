namespace Logistics.Application.Commands.OptimizeLoadPlan;

public sealed record OptimizeLoadPlanCommand(
    Guid TruckId,
    IReadOnlyCollection<Guid> PalletIds);