using UsersWebApiDemo.WebApi.Common.Users;
using UsersWebApiDemo.WebApi.Data.Models;

namespace UsersWebApiDemo.WebApi.Users;

public interface IUserService
{
    Task<UserDto?> CheckUserPasswordAsync(string email, string password, CancellationToken ct);
    Task<bool> AddUserAsync(User user, CancellationToken ct);
    Task<bool> UpdateUserAsync(User user, CancellationToken ct);
    Task<bool> DeleteUserAsync(int userId, CancellationToken ct);
    Task<UserDto?> GetUserByIdAsync(int userId, CancellationToken ct);
}
