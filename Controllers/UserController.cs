using Blogs_Api_DotNet.Abstractions.Services;
using Blogs_Api_DotNet.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blogs_Api_DotNet.Controllers;

[Route("user")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post(UserDTO userDTO)
    {
        var token = await _userService.PostUser(userDTO);
        return Ok(new { token });
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _userService.GetAllUsers());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _userService.GetByFunc(x => x.Id == id));
    }

    [HttpDelete("me")]
    public async Task<IActionResult> DeleteAccount()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        await _userService.DeleteAccount(userId);
        return StatusCode(204);
    }
}
