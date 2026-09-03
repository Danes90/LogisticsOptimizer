using Logistics.Domain.ValueObjects;
namespace Logistics.Domain.Entities;

public sealed class Placement
{

    public Pallet Pallet { get; private set; }
    public Position Position { get; private set; }
    public bool Rotated { get; private set; }

    public Placement(
        Pallet pallet,
        Position position,
        bool rotated
        )
    {
        Pallet = pallet ??
            throw new ArgumentNullException(nameof(pallet));

        Position = position ??
            throw new ArgumentNullException(nameof(position));

        Rotated = rotated;
    }
}
