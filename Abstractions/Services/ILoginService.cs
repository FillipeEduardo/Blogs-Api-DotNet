using Blogs_Api_DotNet.DTO;

namespace Blogs_Api_DotNet.Abstractions.Services
{
    public interface ILoginService
    {
        Task Login(UserDTO userDTO);
    }
}
