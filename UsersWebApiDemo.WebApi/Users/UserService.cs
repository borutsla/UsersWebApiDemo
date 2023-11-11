using Mapster;
using Microsoft.EntityFrameworkCore;
using UsersWebApiDemo.WebApi.Common.Users;
using UsersWebApiDemo.WebApi.Data;
using UsersWebApiDemo.WebApi.Data.Models;

namespace UsersWebApiDemo.WebApi.Users;

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;

    public UserService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserDto?> CheckUserPasswordAsync(string email, string password, CancellationToken ct)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password, ct);
        return user != null ? user.Adapt<UserDto>() : null;
    }

    public async Task<bool> AddUserAsync(UserDto userDto, CancellationToken ct)
    {
        // Create a new user
        var newUser = userDto.Adapt<User>();

        // Add the user to the database
        _dbContext.Users.Add(newUser);
        await _dbContext.SaveChangesAsync(ct);

        return true; // User added successfully
    }

    public async Task<bool> UpdateUserAsync(UserDto userDto, CancellationToken ct)
    {
        // Retrieve the user from the database
        var user = await _dbContext.Users.FindAsync(userDto.Id, ct);

        // Check if the user exists
        if (user == null)
        {
            return false; // User not found
        }

        user.Adapt(userDto);

        // Save changes to the database
        await _dbContext.SaveChangesAsync(ct);

        return true; // User updated successfully
    }

    public async Task<bool> DeleteUserAsync(int userId, CancellationToken ct)
    {
        // Retrieve the user from the database
        var user = await _dbContext.Users.FindAsync(userId, ct);

        // Check if the user exists
        if (user == null)
        {
            return false; // User not found
        }

        // Remove the user from the database
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync(ct);

        return true; // User deleted successfully
    }

    public async Task<UserDto?> GetUserByIdAsync(int userId, CancellationToken ct)
    {
        // Retrieve the user from the database
        var user = await _dbContext.Users.FindAsync(userId, ct);

        // Check if the user exists
        if (user == null)
        {
            return null; // User not found
        }

        // return user
        return user.Adapt<UserDto>();
    }
}
