using System.ComponentModel.DataAnnotations;

namespace UsersWebApiDemo.WebApi.Data.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string UserName { get; set; } = null!;
    [MaxLength(100)]
    public string FullName { get; set; } = null!;
    [MaxLength(100)]
    public string Email { get; set; } = null!;
    [MaxLength(20)]
    public string MobileNumber { get; set; } = null!;
    [MaxLength(50)]
    public string Language { get; set; } = null!;
    [MaxLength(10)]
    public string Culture { get; set; } = null!;
    [MaxLength(50)]
    public string Password { get; set; } = null!;
}
