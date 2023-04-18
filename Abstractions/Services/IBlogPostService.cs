using Blogs_Api_DotNet.DTO;
using Blogs_Api_DotNet.Models;

namespace Blogs_Api_DotNet.Abstractions.Services
{
    public interface IBlogPostService
    {
        Task<BlogPost> CreatePost(BlogPostDTO blogPostDTO, string email);
        Task<List<BlogPost>> GetAll();
        Task<BlogPost> GetById(int id);
        Task<BlogPost> UpdatePost(int id, PostUpdateDTO postUpdateDTO, string email);
    }
}
