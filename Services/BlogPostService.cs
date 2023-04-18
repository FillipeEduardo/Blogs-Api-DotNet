using Blogs_Api_DotNet.Abstractions.Services;
using Blogs_Api_DotNet.Data;
using Blogs_Api_DotNet.DTO;
using Blogs_Api_DotNet.Exceptions;
using Blogs_Api_DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogs_Api_DotNet.Services;

public class BlogPostService : IBlogPostService
{
    private readonly AppDbContext _context;
    private readonly IUserService _userService;

    public BlogPostService(AppDbContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }

    public async Task<BlogPost> CreatePost(BlogPostDTO blogPostDTO, string email)
    {
        List<Category> categories = new();
        foreach (var id in blogPostDTO.CategoryIds)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null) throw new DbNullException("one or more \"categoryIds\" not found");
            categories.Add(category);
        }
        var user = await _userService.GetByFunc(x => x.Email == email);
        var post = new BlogPost
        {
            Title = blogPostDTO.Title,
            Content = blogPostDTO.Content,
            UserId = user.Id,
            Published = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Categories = categories
        };
        await _context.BlogPosts.AddAsync(post);
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<List<BlogPost>> GetAll()
    {
        return _context.BlogPosts.Include(x => x.User).Include(x => x.Categories).ToList();
    }

    public async Task<BlogPost> GetById(int id)
    {
        var result = await _context.BlogPosts
            .Include(x => x.User)
            .Include(x => x.Categories)
            .FirstOrDefaultAsync(x => x.Id == id);
        return result == null ? throw new DbNullException("Post does not exist") : result;
    }

    public async Task<BlogPost> UpdatePost(int id, PostUpdateDTO postUpdateDTO, string email)
    {
        var post = await _context.BlogPosts
            .Include(x => x.User)
            .Include(x => x.Categories)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (post == null) throw new DbNullException("Post does not exist");
        if (post.User.Email != email) throw new UnauthorizedAccessException("Unauthorized user");
        post.Content = postUpdateDTO.Content;
        post.Title = postUpdateDTO.Title;
        await _context.SaveChangesAsync();
        return post;
    }
}
