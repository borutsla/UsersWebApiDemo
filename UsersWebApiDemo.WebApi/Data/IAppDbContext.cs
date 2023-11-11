using Microsoft.EntityFrameworkCore;
using UsersWebApiDemo.WebApi.Data.Models;

namespace UsersWebApiDemo.WebApi.Data;

public interface IAppDbContext
{
    DbSet<User> Users { get; set; }
}
