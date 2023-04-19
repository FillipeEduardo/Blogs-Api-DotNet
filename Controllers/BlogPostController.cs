using Blogs_Api_DotNet.Abstractions.Services;
using Blogs_Api_DotNet.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var result = await _service.CreatePost(blogPostDTO, userId);
        return Created($"post/{result.Id}", result);
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
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        return Ok(await _service.UpdatePost(id, post, userId));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        await _service.DeletePost(id, userId);
        return StatusCode(204);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchByTerm([FromQuery] string q)
    {
        return Ok(await _service.SearchByTerm(q));
    }
}
