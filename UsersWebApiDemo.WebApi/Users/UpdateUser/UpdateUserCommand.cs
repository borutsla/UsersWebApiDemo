using Mapster;
using UsersWebApiDemo.WebApi.Common.Interfaces;
using UsersWebApiDemo.WebApi.Common.Service;
using UsersWebApiDemo.WebApi.Data.Models;

namespace UsersWebApiDemo.WebApi.Users.UpdateUser;

public class UpdateUserCommand : IRequestWrapper<bool>
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string MobileNumber { get; set; } = null!;
    public string Language { get; set; } = null!;
    public string Culture { get; set; } = null!;

}

public class UpdateUserCommandHandler : IRequestHandlerWrapper<UpdateUserCommand, bool>
{
    private readonly IUserService _userService;

    public UpdateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ServiceResult<bool>> Handle(UpdateUserCommand command, CancellationToken ct)
    {
        var userUpdated = await _userService.UpdateUserAsync(command.Adapt<User>(), ct);

        if (!userUpdated)
            return ServiceResult.Failed<bool>(ServiceError.UserFailedToUpdate);


        return ServiceResult.Success(true);
    }

}
