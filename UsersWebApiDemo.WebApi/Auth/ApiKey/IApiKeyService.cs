namespace UsersWebApiDemo.WebApi.Auth.ApiKey;

public interface IApiKeyService
{
    string GenerateApiKey(int userId);
}
