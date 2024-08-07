using Microsoft.EntityFrameworkCore;
using Toing.Configuration;
using Toing.Data;

var builder = WebApplication.CreateBuilder(args);

ServiceConfiguration.ConfigureServices(builder);

var app = builder.Build();

MiddlewareConfiguration.MapGrpcService(app);
MiddlewareConfiguration.CofigureMiddleware(app);

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    var context = services.GetRequiredService<AppDbContext>();

//     try
//     {
//         for (int i = 0; i < 10; ++i)
//         {
            try
            {
                logger.LogInformation("attempting");
                context.Database.Migrate();
                logger.LogInformation("connected");
//                 break;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database.");
//                 Thread.Sleep(5000);
            }
//         }
//     }
//     catch (Exception ex)
//     {
//         logger.LogError(ex, "could not connect to the db");
//     }
}

app.Run();
