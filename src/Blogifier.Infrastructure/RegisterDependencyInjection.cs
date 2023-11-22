using Blogifier.Application;
using Blogifier.Domain;
using Blogifier.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blogifier.Infrastructure;

public static class RegisterDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var home = Environment.GetEnvironmentVariable("HOME") ?? "";
        var databasePath = Path.Combine(home, "BlogifierDb.sqlite");
        // Add BlogifierDbContext to DI
        services.AddDbContext<BlogifierDbContext>(options =>
                   options.UseSqlite($"Data Source={databasePath}"));

        // Add BlogRepository to DI
        services.AddScoped<IRepository<Blog, int>, BlogRepository>();
        services.AddScoped<IRepository<BlogPost, int>, BlogPostRepository>();

        return services;
    }
}
