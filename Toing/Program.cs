using Toing.Configuration;

var builder = WebApplication.CreateBuilder(args);

ServiceConfiguration.ConfigureServices(builder);

var app = builder.Build();

MiddlewareConfiguration.MapGrpcService(app);
MiddlewareConfiguration.CofigureMiddleware(app);

// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Toing API", Version = "v1" });
// });
// 
// // NOTE : if this doesn't exist, get error when call app.UseAuthorization();
// builder.Services.AddControllers();
// 
// builder.Services.AddDbContext<AddDbContext>();
// 
// builder.Services.AddGrpc();
// 
// var app = builder.Build();
// 
// // Configure the HTTP request pipeline.
// // if (app.Environment.IsDevelopment())
// // {
//     app.UseSwagger();
//     app.UseSwaggerUI(c =>
//     {
//         c.SwaggerEndpoint("/swagger/v1/swagger.json", "Toing API v1");
//         c.RoutePrefix = string.Empty;
//     });
// // }
// 
// app.UseForwardedHeaders();
// if (app.Environment.IsDevelopment())
// {
//     app.UseDeveloperExceptionPage();
// }
// else
// {
//     app.UseHsts();
// }
// 
// app.UseHttpsRedirection();
// app.UseAuthorization();
// app.MapControllers();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };
// 
// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
