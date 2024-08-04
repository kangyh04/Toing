namespace Toing.Configuration
{
    public class MiddlewareConfiguration
    {
        public static void CofigureMiddleware(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Toing API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }
        }

        public static void MapGrpcService(WebApplication app)
        {

        }
    }
}
