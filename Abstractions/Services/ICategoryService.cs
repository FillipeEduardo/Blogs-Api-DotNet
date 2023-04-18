using Blogs_Api_DotNet.DTO;
using Blogs_Api_DotNet.Models;
using System.Linq.Expressions;

namespace Blogs_Api_DotNet.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<Category> PostCategory(CategoryDTO categoryDTO);
        Task<Category> GetByFunc(Expression<Func<Category, bool>> func);
        Task<List<Category>> GetAll();
    }
}
