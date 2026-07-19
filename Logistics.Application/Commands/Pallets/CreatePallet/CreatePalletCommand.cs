namespace Logistics.Application.Commands.CreatePallet;

public sealed record CreatePalletCommand(
    int Length,
    int Width,
    int Height,
    int Weight);