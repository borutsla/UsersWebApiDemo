using System.Text;
using UsersWebApiDemo.WebApi.Auth.ApiKey;

namespace UsersWebApiDemo.WebApi.Common.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;
    private readonly IApiKeyService _apiKeyService;


    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger, IApiKeyService apiKeyService)
    {
        _next = next;
        _logger = logger;       
        _apiKeyService = apiKeyService;
    }

    public async Task Invoke(HttpContext context)
    {
        // Capture request details
        context.Request.Headers.TryGetValue("X-Api-Key", out var apiKey);
        string? clientIP = context.Connection.RemoteIpAddress?.ToString();
        string clientName = _apiKeyService.GetUsername(apiKey) ?? "Anonymouse";
        string machineName = Environment.MachineName;
        string apiMethod = context.Request.Path;
        string requestParameters = await GetRequestParameters(context.Request);       

        // Call the next middleware in the pipeline
        await _next(context);        

        // Log request details
        _logger.LogInformation("Request: {ClientIP} {ClientName} {MachineName} {ApiMethod} {RequestParameters}",
            clientIP, clientName, machineName, apiMethod, requestParameters);        
    }

    private async Task<string> GetRequestParameters(HttpRequest request)
    {
        // Capture request parameters
        if (request.Method == HttpMethods.Post || request.Method == HttpMethods.Put)
        {
            try
            {
                // Enable buffering to allow multiple reads on the request body
                request.EnableBuffering();

                // Read the request body
                using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
                {
                    string requestBody = await reader.ReadToEndAsync();

                    // Reset the position of the request body stream so it can be read again by other middleware
                    request.Body.Position = 0;

                    return requestBody;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error reading request body: {ErrorMessage}", ex.Message);
                // Handle the exception or return an appropriate value based on your application's requirements
                return "ErrorReadingRequestBody";
            }
        }

        return request.QueryString.ToString();
    }
}

public static class RequestLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLoggingMiddleware>();
    }
}
