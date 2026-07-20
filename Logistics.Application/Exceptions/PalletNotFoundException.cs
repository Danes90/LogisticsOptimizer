namespace Logistics.Application.Exceptions;

public sealed class PalletNotFoundException
    : Exception
{
    public PalletNotFoundException()
        : base("One or more pallets were not found.")
    {
    }
}