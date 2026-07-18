namespace Logistics.Application.Commands.CreateTruck;

public sealed record CreateTruckCommand(
    int Length,
    int Width,
    int Height,
    int MaxWeight);