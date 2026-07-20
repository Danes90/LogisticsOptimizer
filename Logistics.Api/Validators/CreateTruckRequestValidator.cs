using FluentValidation;
using Logistics.Api.Contracts.Trucks;

namespace Logistics.Api.Validators;

public sealed class CreateTruckRequestValidator
    : AbstractValidator<CreateTruckRequest>
{
    public CreateTruckRequestValidator()
    {
        RuleFor(x => x.Length)
            .GreaterThan(0);

        RuleFor(x => x.Width)
            .GreaterThan(0);

        RuleFor(x => x.Height)
            .GreaterThan(0);

        RuleFor(x => x.MaxWeight)
            .GreaterThan(0);
    }
}