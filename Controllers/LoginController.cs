using Blogs_Api_DotNet.Abstractions.Services;
using Blogs_Api_DotNet.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Blogs_Api_DotNet.Controllers;

[ApiController]
[Route("login")]
public class LoginController : ControllerBase
{
    private ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserDTO userDTO)
    {
        var token = await _loginService.Login(userDTO);
        return Ok(new { token });
    }
}
