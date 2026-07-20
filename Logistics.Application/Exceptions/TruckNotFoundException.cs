namespace Logistics.Application.Exceptions;

public sealed class TruckNotFoundException
    : Exception
{
    public TruckNotFoundException(Guid truckId)
        : base($"Truck '{truckId}' was not found.")
    {
    }
}