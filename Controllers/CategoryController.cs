using Blogs_Api_DotNet.Abstractions.Services;
using Blogs_Api_DotNet.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogs_Api_DotNet.Controllers;

[ApiController]
[Route("categories")]
[Authorize]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _categoryService.GetByFunc(x => x.Id == id));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CategoryDTO categoryDTO)
    {
        var result = await _categoryService.PostCategory(categoryDTO);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }
}
