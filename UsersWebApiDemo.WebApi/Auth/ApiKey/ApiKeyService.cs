namespace UsersWebApiDemo.WebApi.Auth.ApiKey;

public class ApiKeyService : IApiKeyService
{
    public List<string> ValidApiKeys { get; set; }

    public ApiKeyService()
    {
        ValidApiKeys = new();
    }

    public string GenerateApiKey(string userName)
    {
        // Generate a new API key
        var newGuid = Guid.NewGuid().ToString();

        // Add API key
        ValidApiKeys.Add(newGuid);

        return newGuid;
    }

    public bool IsApiKeyValid(string? apiKey)
    {
        if (apiKey == null) return false;

        return ValidApiKeys.Contains(apiKey);
    }
}
