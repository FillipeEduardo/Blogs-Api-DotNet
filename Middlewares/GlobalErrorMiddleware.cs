using Blogs_Api_DotNet.Exceptions;
using System.Text.Json;

namespace Blogs_Api_DotNet.Middlewares
{
    public class GlobalErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DbNullException ex)
            {
                await HandlerErrorAsync(context, ex, 400);
            }
            catch (DuplicatedUserException ex)
            {
                await HandlerErrorAsync(context, ex, 409);
            }
            catch (UnauthorizedAccessException ex)
            {
                await HandlerErrorAsync(context, ex, 401);
            }
            catch (Exception ex)
            {
                await HandlerErrorAsync(context, ex, 500);
            }
        }

        public static Task HandlerErrorAsync(HttpContext context, Exception ex, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var result = JsonSerializer.Serialize(new { message = ex.Message });
            return context.Response.WriteAsync(result);
        }
    }
}
