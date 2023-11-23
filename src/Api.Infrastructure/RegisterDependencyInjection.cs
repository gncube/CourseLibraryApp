using Api.Application;
using Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure;

public static class RegisterDependencyInjection
{
    public static IServiceCollection AddApiInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var home = Environment.GetEnvironmentVariable("HOME") ?? "";
        var databasePath = Path.Combine(home, "CourseLibraryDB.sqlite");

        services.AddDbContext<CourseLibraryContext>(options =>
        {
            options.UseSqlite($"Data Source={databasePath}");
        });

        services.AddScoped<ICourseLibraryRepository, CourseLibraryRepository>();

        return services;
    }
}
