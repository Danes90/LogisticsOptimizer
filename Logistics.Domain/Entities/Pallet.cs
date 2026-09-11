using Logistics.Domain.ValueObjects;

namespace Logistics.Domain.Entities;

public sealed class Pallet
{
    public Guid Id { get; private set; }

    public Dimensions Dimensions { get; private set; }

    public int Weight { get; private set; }

    public int Priority { get; private set; }

    private Pallet()
    {
    }

    public Pallet(
        Guid id,
        Dimensions dimensions,
        int weight,
        int priority)
    {
        if (weight <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(weight));
        }

        Id = id;
        Dimensions = dimensions;
        Weight = weight;
        Priority = priority;
    }
}