using Accounts.Model;
using Accounts.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IAccountsService _service;
    private readonly ILogger<AccountsController> _logger;

    public AccountsController(IAccountsService service, ILogger<AccountsController> logger)
    {
        _service = service;
        _logger = logger;
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Account))]
    public async Task<IActionResult> Create(string name)
    {
        try
        {
            var result = await _service.CreateAsync(name);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
}