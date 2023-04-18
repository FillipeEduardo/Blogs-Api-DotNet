using Blogs_Api_DotNet.DTO;
using Blogs_Api_DotNet.Models;

namespace Blogs_Api_DotNet.Abstractions.Services
{
    public interface IBlogPostService
    {
        Task<BlogPost> CreatePost(BlogPostDTO blogPostDTO, int userId);
        Task<List<BlogPost>> GetAll();
        Task<BlogPost> GetById(int id);
        Task<BlogPost> UpdatePost(int id, PostUpdateDTO postUpdateDTO, int userId);
        Task DeletePost(int id, int userId);
        Task<IEnumerable<BlogPost>> SearchByTerm(string term);
    }
}
