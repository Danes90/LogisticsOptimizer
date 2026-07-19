namespace Logistics.Application.Queries.GetTrucks;

public sealed record TruckDto(
    Guid Id,
    int Length,
    int Width,
    int Height,
    int MaxWeight);