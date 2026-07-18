namespace Logistics.Domain.Services;
using Logistics.Domain.Entities;
using Logistics.Domain.Interfaces;
using Logistics.Domain.ValueObjects;

public sealed class SimpleLoadOptimizer
    : ILoadOptimizer
{
    public LoadPlan Optimize(
    Truck truck,
    IReadOnlyCollection<Pallet> pallets)
    {
        var placements = new List<Placement>();

        var currentX = 0;

        var usedLength = 0;

        foreach (var pallet in pallets)
        {
            usedLength += pallet.Dimensions.Length;

            if (usedLength > truck.Dimensions.Length)
            {
                throw new InvalidOperationException(
                    "Pallets exceed truck length.");
            }
        }

        foreach (var pallet in pallets)
        {
            placements.Add(
                new Placement(
                    pallet,
                    new Position(
                        currentX,
                        0)));

            currentX += pallet.Dimensions.Length;
        }

        return new LoadPlan(
            truck,
            placements);
    }
}