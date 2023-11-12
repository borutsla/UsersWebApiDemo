using System.Collections.Concurrent;

namespace UsersWebApiDemo.WebApi.Auth.ApiKey;

public class ApiKeyService : IApiKeyService
{
    public ConcurrentDictionary<string, string> ValidApiKeys { get; set; }

    public ApiKeyService()
    {
        ValidApiKeys = new();
    }

    public string GenerateApiKey(string userName)
    {
        // Generate a new API key
        var newGuid = Guid.NewGuid().ToString();

        // Add or update the API key in the dictionary
        ValidApiKeys.AddOrUpdate(userName, newGuid, (_, oldValue) => newGuid);

        return newGuid;
    }

    public bool IsApiKeyValid(string? apiKey)
    {
        if (apiKey == null) return false;

        // Check if the API key exists in the dictionary
        return ValidApiKeys.ContainsKey(apiKey);
    }

    public string? GetUsername(string? apiKey)
    {
        // Find the username associated with the given API key
        var username = ValidApiKeys.FirstOrDefault(kv => kv.Value == apiKey).Key;

        return username;
    }
}
