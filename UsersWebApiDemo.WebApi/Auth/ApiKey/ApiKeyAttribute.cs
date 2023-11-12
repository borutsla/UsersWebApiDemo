using Microsoft.AspNetCore.Mvc;

namespace UsersWebApiDemo.WebApi.Auth.ApiKey;

public class ApiKeyAttribute : ServiceFilterAttribute
{
    public ApiKeyAttribute()
        : base(typeof(ApiKeyAuthorizationFilter))
    {
    }
}
