namespace Logistics.Domain.Interfaces;
using Logistics.Domain.Entities;

public interface ILoadOptimizer
{
    LoadPlan Optimize(
        Truck truck,
        IReadOnlyCollection<Pallet> pallets);
}