namespace UsersWebApiDemo.WebApi.Auth.ApiKey;

public interface IApiKeyService
{
    string GenerateApiKey(string userName);
    bool IsApiKeyValid(string? apiKey);
    string? GetUsername(string? apiKey);
}
