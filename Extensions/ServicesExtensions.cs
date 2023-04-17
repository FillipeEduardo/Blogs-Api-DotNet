using Blogs_Api_DotNet.Abstractions.Auth;
using Blogs_Api_DotNet.Abstractions.Services;
using Blogs_Api_DotNet.DTO.Mappings;
using Blogs_Api_DotNet.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Blogs_Api_DotNet.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddAutoMapper(typeof(BlogProfile));
        return services;
    }

    public static IServiceCollection AddAutenticacao(this IServiceCollection services, ConfigurationManager config)
    {
        var key = Encoding.ASCII.GetBytes(config["Jwt:Key"]);
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        return services;
    }
}
