using UsersWebApiDemo.WebApi.Common.Users;

namespace UsersWebApiDemo.WebApi.Users;

public interface IUserService
{
    Task<UserDto?> CheckUserPasswordAsync(string email, string password, CancellationToken ct);
    Task<bool> AddUserAsync(UserDto userDto, CancellationToken ct);
    Task<bool> UpdateUserAsync(UserDto userDto, CancellationToken ct);
    Task<bool> DeleteUserAsync(int userId, CancellationToken ct);
    Task<UserDto?> GetUserByIdAsync(int userId, CancellationToken ct);
}
