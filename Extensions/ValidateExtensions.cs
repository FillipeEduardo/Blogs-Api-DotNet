using Blogs_Api_DotNet.DTO;
using Blogs_Api_DotNet.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Blogs_Api_DotNet.Extensions
{
    public static class ValidateExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            return services.AddScoped<IValidator<UserDTO>, UserValidator>();
        }
    }
}
