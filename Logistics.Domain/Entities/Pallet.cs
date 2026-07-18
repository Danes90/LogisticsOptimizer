namespace Logistics.Domain.Entities;
using Logistics.Domain.ValueObjects;

public sealed class Pallet
{
    public Guid Id { get; }
    public Dimensions Dimensions { get; }
    public int Weight { get; }

    public Pallet(
        Guid id,
        Dimensions dimensions,
        int weight)
    {
        if (weight <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(weight));
        }

        Id = id;
        Dimensions = dimensions;
        Weight = weight;
    }
}