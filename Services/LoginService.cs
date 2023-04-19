using AutoMapper;
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
    private readonly IMapper _mapper;

    public LoginService(AppDbContext context, ITokenService tokenService, IMapper mapper)
    {
        _context = context;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task<string> Login(LoginDTO loginDTO)
    {
        User user = _mapper.Map<User>(loginDTO);
        var data = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
        if (data is null || user.Password != data.Password) throw new DbNullException("Invalid fields");
        return _tokenService.GenerateToken(data);
    }

}
