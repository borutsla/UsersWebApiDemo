using UsersWebApiDemo.WebApi.Common.Middleware;

namespace UsersWebApiDemo.WebApi;

public static partial class MiddlewareInitializer
{
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
        app.UseRequestLoggingMiddleware();

        return app;
    }
}
