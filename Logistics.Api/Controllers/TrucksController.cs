using Logistics.Api.Contracts.Trucks;
using Logistics.Application.Commands.CreateTruck;
using Logistics.Application.Commands.DeleteTruck;
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
    private readonly DeleteTruckHandler _deleteTruckHandler;

    public TrucksController(
        CreateTruckHandler createHandler,
        GetTrucksHandler getHandler,
        GetTruckByIdHandler getTruckByIdHandler,
        DeleteTruckHandler deleteTruckHandler)
    {
        _handler = createHandler;
        _getTrucksHandler = getHandler;
        _getTruckByIdHandler = getTruckByIdHandler;
        _deleteTruckHandler = deleteTruckHandler;
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

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
    Guid id,
    CancellationToken cancellationToken)
    {
        await _deleteTruckHandler.Handle(
            new DeleteTruckCommand(id),
            cancellationToken);

        return NoContent();
    }
}