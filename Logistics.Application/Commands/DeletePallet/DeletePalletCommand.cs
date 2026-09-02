namespace Logistics.Application.Commands.DeletePallet;

public sealed record DeletePalletCommand(
    Guid PalletId);