using Blogs_Api_DotNet.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Blogs_Api_DotNet.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(UserDTO userDTO)
        {
            return Ok(userDTO);
        }
    }
}
