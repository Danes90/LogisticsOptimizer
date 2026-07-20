using FluentValidation;
using Logistics.Api.Contracts.Optimization;

namespace Logistics.Api.Validators;

public sealed class OptimizeLoadPlanRequestValidator
    : AbstractValidator<OptimizeLoadPlanRequest>
{
    public OptimizeLoadPlanRequestValidator()
    {
        RuleFor(x => x.TruckId)
            .NotEmpty();

        RuleFor(x => x.PalletIds)
            .NotEmpty();
    }
}