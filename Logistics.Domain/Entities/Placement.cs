using Logistics.Domain.ValueObjects;

namespace Logistics.Domain.Entities;


public sealed class Placement
{

    public Pallet Pallet { get; }

    public Position Position { get; }

    public Placement(
        Pallet pallet,
        Position position)
    {
        Pallet = pallet ??
            throw new ArgumentNullException(nameof(pallet));

        Position = position ??
            throw new ArgumentNullException(nameof(position));
    }

}
