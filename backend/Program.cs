using backend.Filters;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

namespace backend;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<HttpExceptionFilter>();
            options.Filters.Add<ExceptionFilter>();
        });

        builder.Services.AddDbContext<DayContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

        builder.Services.AddScoped<AuthService>();
        builder.Services.AddScoped<HashService>();
        builder.Services.AddScoped<TokenService>();

        builder.Services.Configure<KestrelServerOptions>(options =>
        {
            options.AllowSynchronousIO = true;
        });

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        WebApplication app = builder.Build();

        app.Use(async (context, next) =>
        {
            context.Request.EnableBuffering();
            await next();
        });

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors();


        app.MapControllers();

        app.Run();
    }
}
