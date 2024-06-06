using System.Net.NetworkInformation;

namespace ApiGateway.Middlewares;
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate Next;
    private readonly ILogger<RequestLoggingMiddleware> Logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        Next = next;
        Logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var ipAddress = context.Connection.RemoteIpAddress?.ToString();
        
        var currentTime = DateTime.Now;

        Logger.LogInformation($"[{currentTime}] Request from IP: {ipAddress}.");

        await Next(context);
    }
}
