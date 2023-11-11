using UsersWebApiDemo.WebApi.Common.Interfaces;
using UsersWebApiDemo.WebApi.Common.Service;

namespace UsersWebApiDemo.WebApi.Users.DeleteUser;

public class DeleteUserCommand : IRequestWrapper<bool>
{
    public int UserId { get; set; }

}

public class DeleteUserCommandHandler : IRequestHandlerWrapper<DeleteUserCommand, bool>
{
    private readonly IUserService _userService;

    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ServiceResult<bool>> Handle(DeleteUserCommand command, CancellationToken ct)
    {
        var userUpdated = await _userService.DeleteUserAsync(command.UserId, ct);

        if (!userUpdated)
            return ServiceResult.Failed<bool>(ServiceError.UserFailedToDelete);


        return ServiceResult.Success(true);
    }

}
