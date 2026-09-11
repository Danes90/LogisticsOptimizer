namespace Logistics.Domain.Entities;

public sealed class PlacementResult
{
    public Guid Id { get; private set; }

    public Guid LoadPlanId { get; private set; }

    public Guid PalletId { get; private set; }

    public int X { get; private set; }

    public int Y { get; private set; }

    public bool Rotated { get; private set; }

    private PlacementResult()
    {
    }

    public PlacementResult(
        Guid loadPlanId,
        Guid palletId,
        int x,
        int y,
        bool rotated)
    {
        Id = Guid.NewGuid();
        LoadPlanId = loadPlanId;
        PalletId = palletId;
        X = x;
        Y = y;
        Rotated = rotated;
    }
}
