using Blogs_Api_DotNet.Data;

namespace Blogs_Api_DotNet.Services;

public class LoginService
{
    private AppDbContext _context;

    public LoginService(AppDbContext context)
    {
        _context = context;
    }


}
