using Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Extensions
{
    public static class RateLimitExtension
    {
        public static IApplicationBuilder UseRateLimiting(this IApplicationBuilder builder, int limit, TimeSpan? duration)
        {
            return builder.UseMiddleware<RateLimitMiddleware>(limit, duration);
        }
    }
}
