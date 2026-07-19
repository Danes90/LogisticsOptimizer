using Logistics.Api.Contracts.Optimization;
using Logistics.Application.Commands.OptimizeLoadPlan;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Api.Controllers;

[ApiController]
[Route("api/optimization")]
public sealed class OptimizationController : ControllerBase
{
    private readonly OptimizeLoadPlanHandler _handler;

    public OptimizationController(
        OptimizeLoadPlanHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Optimize(
        OptimizeLoadPlanRequest request,
        CancellationToken cancellationToken)
    {
        var result =
            await _handler.Handle(
                new OptimizeLoadPlanCommand(
                    request.TruckId,
                    request.PalletIds),
                cancellationToken);

        return Ok(result);
    }
}