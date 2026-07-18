using Logistics.Api.Contracts.Trucks;
using Logistics.Application.Commands.CreateTruck;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Api.Controllers;

[ApiController]
[Route("api/trucks")]
public sealed class TrucksController : ControllerBase
{
    private readonly CreateTruckHandler _handler;

    public TrucksController(
        CreateTruckHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateTruckRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateTruckCommand(
            request.Length,
            request.Width,
            request.Height,
            request.MaxWeight);

        await _handler.Handle(
            command,
            cancellationToken);

        return Ok();
    }
}