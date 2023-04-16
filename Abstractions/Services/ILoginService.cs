using Blogs_Api_DotNet.DTO;

namespace Blogs_Api_DotNet.Abstractions.Services
{
    public interface ILoginService
    {
        Task<string> Login(UserDTO userDTO);
    }
}
