using AutoMapper;
using Blogs_Api_DotNet.Abstractions.Auth;
using Blogs_Api_DotNet.Abstractions.Services;
using Blogs_Api_DotNet.Data;
using Blogs_Api_DotNet.DTO;
using Blogs_Api_DotNet.Exceptions;
using Blogs_Api_DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogs_Api_DotNet.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserService(AppDbContext context, IMapper mapper, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<string> PostUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var data = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (data != null) throw new DuplicatedUserException("User already registered");
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return _tokenService.GenerateToken(user);
        }
    }
}
