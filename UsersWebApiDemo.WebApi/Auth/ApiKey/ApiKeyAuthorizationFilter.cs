using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace UsersWebApiDemo.WebApi.Auth.ApiKey;

public class ApiKeyAuthorizationFilter : IAuthorizationFilter
{
    private const string ApiKeyHeaderName = "X-API-Key";

    private readonly IApiKeyService _apiKeyService;

    public ApiKeyAuthorizationFilter(IApiKeyService apiKeyService)
    {
        _apiKeyService = apiKeyService;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string? apiKey = context.HttpContext.Request.Headers[ApiKeyHeaderName];
        //string? currentUsername = context.HttpContext.User.Identity?.Name;

        if (!_apiKeyService.IsApiKeyValid(apiKey))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
