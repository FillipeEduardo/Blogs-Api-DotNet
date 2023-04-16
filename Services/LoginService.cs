using Blogs_Api_DotNet.Abstractions.Auth;
using Blogs_Api_DotNet.Abstractions.Services;
using Blogs_Api_DotNet.Data;
using Blogs_Api_DotNet.DTO;
using Blogs_Api_DotNet.Exceptions;
using Blogs_Api_DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogs_Api_DotNet.Services;

public class LoginService : ILoginService
{
    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;

    public LoginService(AppDbContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<string> Login(UserDTO userDTO)
    {
        var user = new User { Email = userDTO.Email, Password = userDTO.Password };
        var data = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
        if (data is null || user.Password != data.Password) throw new DbNullException("Invalid fields");
        return _tokenService.GenerateToken(data);
    }

}
