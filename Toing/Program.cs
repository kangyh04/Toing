using Microsoft.EntityFrameworkCore;
using Toing.Configuration;
using Toing.Data;

var builder = WebApplication.CreateBuilder(args);

ServiceConfiguration.ConfigureServices(builder);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    try
    {
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

MiddlewareConfiguration.MapGrpcService(app);
MiddlewareConfiguration.CofigureMiddleware(app);

app.Run();
