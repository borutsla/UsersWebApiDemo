namespace UsersWebApiDemo.WebApi.Common.Users;

public class UserDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string FullName { get; set; } = null!;  
    public string Email { get; set; } = null!;   
    public string MobileNumber { get; set; } = null!;
    public string Language { get; set; } = null!;
    public string Culture { get; set; } = null!;
}
