namespace Logistics.Domain.ValueObjects;

public sealed record Dimensions
{
    public int Length { get; }

    public int Width { get; }

    public int Height { get; }

    public Dimensions(
        int length,
        int width,
        int height)
    {
        Validate(length, "Length");
        Validate(width, "Width");
        Validate(height, "Heigth");

        Length = length;
        Width = width;
        Height = height;
    }

    private static void Validate(
        int value,
        string paramName)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(
                paramName,
                $"{paramName} must be greater than zero.");
        }
    }
}