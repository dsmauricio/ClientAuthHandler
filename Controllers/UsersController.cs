using ClientAuthHandler.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientAuthHandler.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IGraphApiService _graphApiService;

    public UsersController(ILogger<UsersController> logger, IGraphApiService graphApiService)
    {
        _logger = logger;
        _graphApiService = graphApiService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _graphApiService.GetUsersAsync();
        return Ok(users);
    }
}
