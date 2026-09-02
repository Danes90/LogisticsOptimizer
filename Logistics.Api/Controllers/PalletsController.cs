using Logistics.Api.Contracts.Pallets;
using Logistics.Application.Commands.CreatePallet;
using Logistics.Application.Commands.DeletePallet;
using Logistics.Application.Commands.DeleteTruck;
using Logistics.Application.Queries.GetPalletById;
using Logistics.Application.Queries.GetPallets;
using Logistics.Application.Queries.GetTruckById;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/pallets")]
public sealed class PalletsController : ControllerBase
{
    private readonly CreatePalletHandler _createHandler;
    private readonly GetPalletsHandler _getHandler;
    private readonly GetPalletByIdHandler _getPalletByIdHandler;
    private readonly DeletePalletHandler  _deletePalletHandler;


    public PalletsController(
        CreatePalletHandler createHandler,
        GetPalletsHandler getHandler,
        GetPalletByIdHandler getPalletByIdHandler,
        DeletePalletHandler deletePalletHandler
        )
    { 
        _createHandler = createHandler;
        _getHandler = getHandler;
        _getPalletByIdHandler = getPalletByIdHandler;
        _deletePalletHandler = deletePalletHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreatePalletRequest request,
        CancellationToken cancellationToken)
    {
        await _createHandler.Handle(
            new CreatePalletCommand(
                request.Length,
                request.Width,
                request.Height,
                request.Weight),
            cancellationToken);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        CancellationToken cancellationToken)
    {
        var result = await _getHandler.Handle(
            new GetPalletsQuery(),
            cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
    Guid id,
    CancellationToken cancellationToken)
    {
        var result =
            await _getPalletByIdHandler.Handle(
                new GetPalletByIdQuery(id),
                cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
    Guid id,
    CancellationToken cancellationToken)
    {
        await _deletePalletHandler.Handle(
            new DeletePalletCommand(id),
            cancellationToken);

        return NoContent();
    }
}