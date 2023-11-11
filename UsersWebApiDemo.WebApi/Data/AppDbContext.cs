using Microsoft.EntityFrameworkCore;
using UsersWebApiDemo.WebApi.Data.Models;

namespace UsersWebApiDemo.WebApi.Data;

public class AppDbContext : DbContext, IAppDbContext
{
    /******
        EF CORE Migrations and Database update
        ADD migration (targeted project with the Db configure, startup project, output(where to put the migration folder) and the context class)
        dotnet ef migrations add Initial --project UsersWebApiDemo.WebApi --startup-project UsersWebApiDemo.WebApi --output-dir Data\Migrations --context AppDbContext

        UPDATE database (targeted project with the Db configure, startup project and the context class)
        dotnet ef database update --project UsersWebApiDemo.WebApi --startup-project UsersWebApiDemo.WebApi --context AppDbContext
     * ***/

    protected readonly IConfiguration Configuration;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlserver with connection string from app settings
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }
}
