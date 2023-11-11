using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using UsersWebApiDemo.WebApi.Auth.ApiKey;
using UsersWebApiDemo.WebApi.Common.Behaviours;
using UsersWebApiDemo.WebApi.Data;
using UsersWebApiDemo.WebApi.Users;

namespace UsersWebApiDemo.WebApi
{
    public static partial class ServiceInitializer
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            // database
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("WebApiDatabase")));

            // Add services to the container.
            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            // Configure Swagger.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1.0",
                    new OpenApiInfo
                    {
                        Description = "Users Web API",
                        Title = "Users Web API",
                        Version = "v1.0"
                    }
                );
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.UseInlineDefinitionsForEnums();
                c.CustomSchemaIds(x => x.FullName);                
            });

            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            // Behaviours
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddTransient<IApiKeyService, ApiKeyService>();
            services.AddTransient<IUserService, UserService>();

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
