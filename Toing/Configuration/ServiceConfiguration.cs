using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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

            services.AddDbContext<AddDbContext>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Toing API", Version = "v1" });
            });

            services.AddGrpc();
        }
    }
}
