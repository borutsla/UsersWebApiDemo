using UsersWebApiDemo.WebApi.Auth.ApiKey;
using UsersWebApiDemo.WebApi.Common.Interfaces;
using UsersWebApiDemo.WebApi.Common.Service;
using UsersWebApiDemo.WebApi.Common.Users;

namespace UsersWebApiDemo.WebApi.Users.GetUser;

public class GetUserRequest : IRequestWrapper<UserDto>
{
    public int UserId { get; set; }
}

public class GetUserCommandHandler : IRequestHandlerWrapper<GetUserRequest, UserDto>
{
    private readonly IUserService _userService;

    public GetUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ServiceResult<UserDto>> Handle(GetUserRequest command, CancellationToken ct)
    {
        var user = await _userService.GetUserByIdAsync(command.UserId, ct);

        if (user == null)
            return ServiceResult.Failed<UserDto>(ServiceError.UserNotFound);


        return ServiceResult.Success(user);
    }

}
