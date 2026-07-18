namespace Logistics.Domain.Entities;

public class LoadPlan
{

    public Truck Truck { get; }

    public IReadOnlyCollection<Placement> Placements { get; }


    public int TotalWeight =>
        Placements.Sum(x => x.Pallet.Weight);

    public bool IsOverWeight =>
    TotalWeight > Truck.MaxWeight;


    public LoadPlan(
        Truck truck,
        IReadOnlyCollection<Placement> placements)
    {
        Truck = truck ??
            throw new ArgumentNullException(
                nameof(truck));

        Placements = placements ??
            throw new ArgumentNullException(
                nameof(placements));
    }

}