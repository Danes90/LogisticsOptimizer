using Logistics.Application.Commands.CreatePallet;
using Logistics.Application.Queries.GetPallets;
using Microsoft.AspNetCore.Mvc;
using Logistics.Api.Contracts.Pallets;

[ApiController]
[Route("api/pallets")]
public sealed class PalletsController : ControllerBase
{
    private readonly CreatePalletHandler _createHandler;
    private readonly GetPalletsHandler _getHandler;


    public PalletsController(
        CreatePalletHandler createHandler,
        GetPalletsHandler getHandler)
    { 
        _createHandler = createHandler;
        _getHandler = getHandler;
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
}