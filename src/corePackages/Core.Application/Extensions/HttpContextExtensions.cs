

using Microsoft.AspNetCore.Http;

namespace Core.Application.Extensions
{
    public static class HttpContextExtensions
    {
         public static string GetIpAddress(this HttpContext context)
    {
        if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
            return context.Request.Headers["X-Forwarded-For"].FirstOrDefault();

        return context.Connection.RemoteIpAddress?.ToString() ?? "UNKNOWN";
    }
    }
}