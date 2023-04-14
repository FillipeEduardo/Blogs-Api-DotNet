using Blogs_Api_DotNet.Data;
using Microsoft.EntityFrameworkCore;

namespace Blogs_Api_DotNet.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services, ConfigurationManager config)
        {
            var connectionString = config.GetConnectionString("Default");
            services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            return services;
        }
    }
}
