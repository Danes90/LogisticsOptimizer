namespace Logistics.Api.Contracts.Trucks;

public sealed record CreateTruckRequest(
    int Length,
    int Width,
    int Height,
    int MaxWeight);