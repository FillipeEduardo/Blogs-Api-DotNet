using AutoMapper;
using Blogs_Api_DotNet.Abstractions.Services;
using Blogs_Api_DotNet.Data;
using Blogs_Api_DotNet.DTO;
using Blogs_Api_DotNet.Exceptions;
using Blogs_Api_DotNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blogs_Api_DotNet.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CategoryService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Category> PostCategory(CategoryDTO categoryDTO)
    {
        var category = _mapper.Map<Category>(categoryDTO);
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> GetByFunc(Expression<Func<Category, bool>> func)
    {
        var result = await _context.Categories.FirstOrDefaultAsync(func);
        return result is null ? throw new DbNullException("Not Found") : result;
    }

    public async Task<List<Category>> GetAll()
    {
        return await _context.Categories.AsNoTracking().ToListAsync();
    }
}
