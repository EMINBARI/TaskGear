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
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserResponse>> GetUser(Guid id)
    {
        var user = await _userService.GetUserAsync(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> CreateUser([FromBody] AddUserRequest request)
    {
        var user = await _userService.AddUserAsync(
            request
        );

        return Ok(user);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<UserResponse>> UpdateUser(Guid id, [FromBody] UpdateUserRequest request)
    {
        var user = await _userService.EditUserAsync(request);
        return Ok(user);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        await _userService.DeleteUserAsync(id);
        return Ok(
            new { message = $"User  with id {id} successfully deleted" }
        );
    }
}