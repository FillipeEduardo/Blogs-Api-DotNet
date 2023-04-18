using Blogs_Api_DotNet.DTO;
using Blogs_Api_DotNet.Models;
using System.Linq.Expressions;

namespace Blogs_Api_DotNet.Abstractions.Services
{
    public interface IUserService
    {
        Task<string> PostUser(UserDTO userDTO);
        Task<List<User>> GetAllUsers();
        Task<User> GetByFunc(Expression<Func<User, bool>> func);
        Task DeleteAccount(int id);
    }
}
