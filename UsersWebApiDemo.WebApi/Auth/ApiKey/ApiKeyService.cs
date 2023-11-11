using System.Collections.Concurrent;

namespace UsersWebApiDemo.WebApi.Auth.ApiKey;

public class ApiKeyService : IApiKeyService
{
    public List<string> ValidApiKeys { get; set; }

    public ApiKeyService()
    {
        ValidApiKeys = new();
    }

    public string GenerateApiKey(int userId)
    {
        var newGuid = Guid.NewGuid().ToString();
        ValidApiKeys.Add(newGuid);
        return newGuid;
    }
}
