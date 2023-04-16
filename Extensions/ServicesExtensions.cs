using Blogs_Api_DotNet.Abstractions.Services;
using Blogs_Api_DotNet.Services;

namespace Blogs_Api_DotNet.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddScoped<ILoginService, LoginService>();
    }
}
