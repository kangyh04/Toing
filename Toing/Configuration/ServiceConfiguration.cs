using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Toing.Data;

namespace Toing.Configuration
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            var services = builder.Services;

            services.AddControllers();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(connectionString);

            services.AddDbContext<AppDbContext>(options =>
            {
                Console.WriteLine("Added Db Context");
                var version = new MySqlServerVersion(new Version(8, 0, 0));
                options.UseMySql(connectionString, version);
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Toing API", Version = "v1" });
            });

            services.AddGrpc();
        }
    }
}
