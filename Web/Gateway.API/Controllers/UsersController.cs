using Microsoft.AspNetCore.Mvc;
using Users.Model;
using Users.Services.Contracts;

namespace Gateway.API.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUsersService service, ILogger<UsersController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(User))]
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
}
