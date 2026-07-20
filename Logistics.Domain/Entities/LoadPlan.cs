namespace Logistics.Domain.Entities;

public sealed class LoadPlan
{
    public Truck Truck { get; private set; }

    public IReadOnlyCollection<Placement> Placements { get; private set; }

    public LoadPlan(
        Truck truck,
        IReadOnlyCollection<Placement> placements)
    {
        Truck = truck ??
            throw new ArgumentNullException(nameof(truck));

        Placements = placements ??
            throw new ArgumentNullException(nameof(placements));
    }

    public int TotalWeight =>
        Placements.Sum(x => x.Pallet.Weight);

    public bool IsOverWeight =>
        TotalWeight > Truck.MaxWeight;
}