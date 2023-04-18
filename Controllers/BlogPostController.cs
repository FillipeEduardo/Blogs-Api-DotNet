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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAll();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetById(id);
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(PostUpdateDTO post, int id)
    {
        return Ok(await _service.UpdatePost(id, post, User.Identity.Name));
    }
}
