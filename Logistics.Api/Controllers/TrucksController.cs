using Logistics.Api.Contracts.Trucks;
using Logistics.Application.Commands.CreateTruck;
using Logistics.Application.Queries.GetTruckById;
using Logistics.Application.Queries.GetTrucks;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Api.Controllers;

[ApiController]
[Route("api/trucks")]
public sealed class TrucksController : ControllerBase
{
    private readonly CreateTruckHandler _handler;
    private readonly GetTrucksHandler _getTrucksHandler;
    private readonly GetTruckByIdHandler _getTruckByIdHandler;

    public TrucksController(
        CreateTruckHandler createHandler,
        GetTrucksHandler getHandler,
        GetTruckByIdHandler getTruckByIdHandler
    )
    {
        _handler = createHandler;
        _getTrucksHandler = getHandler;
        _getTruckByIdHandler = getTruckByIdHandler;
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

    [HttpGet]
    public async Task<IActionResult> GetAll(
    CancellationToken cancellationToken)
    {
        var result = await _getTrucksHandler.Handle(
            new GetTrucksQuery(),
            cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id,CancellationToken cancellationToken)
    {
        var result =
            await _getTruckByIdHandler.Handle(
                new GetTruckByIdQuery(id),
                cancellationToken);

        return Ok(result);
    }
}