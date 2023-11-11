using UsersWebApiDemo.WebApi.Common.Users;

namespace UsersWebApiDemo.WebApi.Auth.Features.Login;

public class LoginResponse
{
    public UserDto User { get; set; } = null!;

    public string ApiKey { get; set; } = null!;
}
