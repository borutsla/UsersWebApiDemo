using UsersWebApiDemo.WebApi.Auth.ApiKey;
using UsersWebApiDemo.WebApi.Common.Interfaces;
using UsersWebApiDemo.WebApi.Common.Service;
using UsersWebApiDemo.WebApi.Users;

namespace UsersWebApiDemo.WebApi.Auth.Features.Login;

public class LoginQuery : IRequestWrapper<LoginResponse>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class LoginQueryHandler : IRequestHandlerWrapper<LoginQuery, LoginResponse>
{
    private readonly IUserService _userService;
    private readonly IApiKeyService _apiKeyService;

    public LoginQueryHandler(IUserService identityService, IApiKeyService apiKeyService)
    {
        _userService = identityService;
        _apiKeyService = apiKeyService;
    }

    public async Task<ServiceResult<LoginResponse>> Handle(LoginQuery request, CancellationToken ct)
    {
        var user = await _userService.CheckUserPasswordAsync(request.Email, request.Password, ct);

        if (user == null)
            return ServiceResult.Failed<LoginResponse>(ServiceError.ForbiddenError);


        return ServiceResult.Success(new LoginResponse
        {
            User = user,
            ApiKey = _apiKeyService.GenerateApiKey(user.Id)
        });
    }

}
