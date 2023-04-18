using Blogs_Api_DotNet.Abstractions.Services;
using Blogs_Api_DotNet.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogs_Api_DotNet.Controllers;

[ApiController]
[Route("post")]
[Authorize]
public class BlogPostController : ControllerBase
{
    private readonly IBlogPostService _service;

    public BlogPostController(IBlogPostService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(BlogPostDTO blogPostDTO)
    {
        var result = await _service.CreatePost(blogPostDTO, User.Identity.Name);
        return Ok(result);
    }
}
