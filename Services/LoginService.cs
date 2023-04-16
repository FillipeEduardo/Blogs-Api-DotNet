using Blogs_Api_DotNet.Abstractions.Services;
using Blogs_Api_DotNet.Data;
using Blogs_Api_DotNet.DTO;
using Blogs_Api_DotNet.Exceptions;
using Blogs_Api_DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogs_Api_DotNet.Services;

public class LoginService : ILoginService
{
    private AppDbContext _context;

    public LoginService(AppDbContext context)
    {
        _context = context;
    }

    public async Task Login(UserDTO userDTO)
    {
        var user = new User { Email = userDTO.Email, Password = userDTO.Password };
        var data = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
        if (data is null) throw new DbNullException("Invalid fields");
    }

}
