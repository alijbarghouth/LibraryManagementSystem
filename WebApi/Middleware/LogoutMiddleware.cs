using System.Security.Claims;
using Microsoft.Extensions.Caching.Distributed;

namespace WebApi.Middleware;

public sealed class LogoutMiddleware : IMiddleware
{
    private readonly IDistributedCache _distributedCache;

    public LogoutMiddleware(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!context.Response.HasStarted && await _distributedCache.GetStringAsync(userId ?? "") is null)
            context.Request.Headers["Authorization"] = string.Empty;

        context.Request.Headers["Authorization"] =
            context.Request.Headers["Authorization"].ToString().Replace("Token", "Bearer");
        await next(context);
    }
}