using Blogs_Api_DotNet.Abstractions.Auth;
using Blogs_Api_DotNet.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blogs_Api_DotNet.Services;

public class TokenService : ITokenService

{
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("dfgd¨96bfgbtf9¨¨(87&&¨B&hgG(*¨T¨(¨TGB(¨*&¨45clk7749324knj32b4234jf2348*B*n*@6n*(%B%f%@fv5@Fv886");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Email),
            }),
            Expires = DateTime.UtcNow.AddDays(5),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
