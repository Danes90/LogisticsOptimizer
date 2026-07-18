namespace Logistics.Domain.Entities;
using Logistics.Domain.ValueObjects;

public sealed class Truck
{
    public Guid Id { get; }

    public Dimensions Dimensions { get; }

    public int MaxWeight { get; }

    private Truck()
    {
    }

    public Truck(
        Guid id,
        Dimensions dimensions,
        int maxWeight)
    {
        if (maxWeight <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(maxWeight));
        }

        Id = id;
        Dimensions = dimensions;
        MaxWeight = maxWeight;
    }
}