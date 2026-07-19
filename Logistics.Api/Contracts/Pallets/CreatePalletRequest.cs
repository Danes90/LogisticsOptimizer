namespace Logistics.Api.Contracts.Pallets;

public sealed record CreatePalletRequest(
    int Length,
    int Width,
    int Height,
    int Weight);