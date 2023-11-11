using Microsoft.EntityFrameworkCore;
using Serilog;
using UsersWebApiDemo.WebApi;
using UsersWebApiDemo.WebApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApplicationServices(builder.Configuration);
// Add serilog support
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

app.ConfigureMiddleware();
app.RegisterEndpoints();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDbContext>();

    await context.Database.MigrateAsync();
}

app.Run();
