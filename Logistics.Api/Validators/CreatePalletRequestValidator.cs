using FluentValidation;
using Logistics.Api.Contracts.Pallets;

namespace Logistics.Api.Validators;

public sealed class CreatePalletRequestValidator
    : AbstractValidator<CreatePalletRequest>
{
    public CreatePalletRequestValidator()
    {
        RuleFor(x => x.Length)
            .GreaterThan(0);

        RuleFor(x => x.Width)
            .GreaterThan(0);

        RuleFor(x => x.Height)
            .GreaterThan(0);

        RuleFor(x => x.Weight)
            .GreaterThan(0);
    }
}