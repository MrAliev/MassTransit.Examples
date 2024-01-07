using Microsoft.AspNetCore.Mvc;
using Wallets.Model;
using Wallets.Service.Contracts;

namespace Gateway.API.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class WalletsController : ControllerBase
{
    private readonly IWalletsService _service;
    private readonly ILogger<WalletsController> _logger;

    public WalletsController(IWalletsService service, ILogger<WalletsController> logger)
    {
        _service = service;
        _logger = logger;
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Wallet))]
    public async Task<IActionResult> Create(Guid parentId)
    {
        try
        {
            var result = await _service.CreateAsync(parentId);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
}