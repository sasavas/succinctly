using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddDbContext<SuccinctlyContext>(
            options =>
            {
                options
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
                    .UseNpgsql( 
                        //TODO: add connectionString via config later
                        "Server=127.0.0.1;" +
                        "Port=5432;" +
                        "Database=succinctly;" +
                        "User Id=usavas;" +
                        "Password=1460;" +
                        "Include Error Detail=True;")
                    .UseSnakeCaseNamingConvention();
            });
    }
}