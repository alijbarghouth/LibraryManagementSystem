namespace WebApi.Middleware;

public sealed class LoggerMiddleware : IMiddleware
{
    private readonly ILogger<LoggerMiddleware> _logger;

    public LoggerMiddleware(ILogger<LoggerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}" +
                                   $" from {context.Connection.RemoteIpAddress}");

            await next(context);

            _logger.LogInformation($"Request completed: {context.Request.Method} {context.Request.Path}" +
                                   $" from {context.Connection.RemoteIpAddress}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message,
                $"Error occurred while processing request: {context.Request.Method} {context.Request.Path}" +
                $" from {context.Connection.RemoteIpAddress}");

            throw;
        }
    }
}