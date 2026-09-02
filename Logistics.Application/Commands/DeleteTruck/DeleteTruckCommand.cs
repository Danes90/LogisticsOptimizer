namespace Logistics.Application.Commands.DeleteTruck;

public sealed record DeleteTruckCommand(
    Guid TruckId);