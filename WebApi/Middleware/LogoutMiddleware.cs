using Domain.Authentication;
using Microsoft.Extensions.Primitives;

namespace WebApi.Middleware;

public sealed class LogoutMiddleware : IMiddleware
{
    private readonly ILogoutRepository _logoutRepository;

    public LogoutMiddleware(ILogoutRepository logoutRepository)
    {
        _logoutRepository = logoutRepository;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.Response.HasStarted && !await _logoutRepository.IsActiveAsync())
            context.Request.Headers["Authorization"] = string.Empty;

        context.Request.Headers["Authorization"] =
            context.Request.Headers["Authorization"].ToString().Replace("Token", "Bearer");
        await next(context);
    }
}
