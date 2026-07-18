namespace Logistics.Domain.ValueObjects;

public sealed record Position
{
    public int X { get; }
    public int Y { get; }

    public Position(
        int x,
        int y)
    {
        if (x < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(x));
        }

        if (y < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(y));
        }

        X = x;
        Y = y;
    }
}