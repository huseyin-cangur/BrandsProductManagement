

using Microsoft.AspNetCore.Builder;


namespace Core.CrossCuttingConcerns.Exceptions.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureCustomExtensionMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionMiddleware>();
    }
}