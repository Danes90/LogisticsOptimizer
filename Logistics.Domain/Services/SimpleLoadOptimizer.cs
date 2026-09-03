using Logistics.Domain.Entities;
using Logistics.Domain.Interfaces;
using Logistics.Domain.ValueObjects;

namespace Logistics.Domain.Services;

public sealed class SimpleLoadOptimizer
    : ILoadOptimizer
{
    public LoadPlan Optimize(
        Truck truck,
        IReadOnlyCollection<Pallet> pallets)
    {
        var placements = new List<Placement>();

        var currentX = 0;
        var currentY = 0;
        var rowHeight = 0;

        foreach (var pallet in pallets)
        {
            var length = pallet.Dimensions.Length;
            var width = pallet.Dimensions.Width;

            var rotated = false;

            // Nem fér el a sorban -> próbáljuk elforgatni
            if (currentX + length > truck.Dimensions.Length)
            {
                if (currentX + width <= truck.Dimensions.Length)
                {
                    (length, width) = (width, length);

                    rotated = true;
                }
                else
                {
                    currentX = 0;
                    currentY += rowHeight;
                    rowHeight = 0;
                }
            }

            // Új sorban sem fér el
            if (currentY + width > truck.Dimensions.Width)
            {
                continue;
            }

            placements.Add(
                new Placement(
                    pallet,
                    new Position(
                        currentX,
                        currentY),
                    rotated));

            currentX += length;

            rowHeight = Math.Max(
                rowHeight,
                width);
        }

        return new LoadPlan(
            truck,
            placements);
    }
}