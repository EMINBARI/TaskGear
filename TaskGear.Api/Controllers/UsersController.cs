using Microsoft.AspNetCore.Mvc;
using TaskGear.Application.Services;
using TaskGear.Application.Services.Contracts;

namespace TaskGear.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserResponse>>> GetUsers()
    {
        var users = await _userService.GetUsersAsync();
        Console.WriteLine(users);

        return Ok(users );
    } 
}