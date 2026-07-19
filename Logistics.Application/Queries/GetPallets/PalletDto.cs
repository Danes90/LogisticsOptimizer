namespace Logistics.Application.Queries.GetPallets;

public sealed record PalletDto(
    Guid Id,
    int Length,
    int Width,
    int Height,
    int Weight);