using Blogs_Api_DotNet.Models;

namespace Blogs_Api_DotNet.Abstractions.Auth
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
