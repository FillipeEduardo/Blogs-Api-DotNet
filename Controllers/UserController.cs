using Blogs_Api_DotNet.Abstractions.Services;
using Blogs_Api_DotNet.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Blogs_Api_DotNet.Controllers;

[Route("user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserDTO userDTO)
    {
        var token = await _userService.PostUser(userDTO);
        return Ok(new { token });
    }
}
