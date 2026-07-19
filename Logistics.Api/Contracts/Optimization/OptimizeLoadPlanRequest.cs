namespace Logistics.Api.Contracts.Optimization;

public sealed record OptimizeLoadPlanRequest(
    Guid TruckId,
    IReadOnlyCollection<Guid> PalletIds);