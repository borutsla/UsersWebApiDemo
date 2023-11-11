using Mapster;
using UsersWebApiDemo.WebApi.Common.Interfaces;
using UsersWebApiDemo.WebApi.Common.Service;
using UsersWebApiDemo.WebApi.Data.Models;

namespace UsersWebApiDemo.WebApi.Users.AddUser;

public class AddUserCommand : IRequestWrapper<bool>
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string MobileNumber { get; set; } = null!;
    public string Language { get; set; } = null!;
    public string Culture { get; set; } = null!;

}

public class AddUserCommandHandler : IRequestHandlerWrapper<AddUserCommand, bool>
{
    private readonly IUserService _userService;

    public AddUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ServiceResult<bool>> Handle(AddUserCommand command, CancellationToken ct)
    {
        var userAdded = await _userService.AddUserAsync(command.Adapt<User>(), ct);

        if (!userAdded)
            return ServiceResult.Failed<bool>(ServiceError.UserFailedToCreate);


        return ServiceResult.Success(true);
    }

}
