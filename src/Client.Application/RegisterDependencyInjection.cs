using Blogifier.Domain;
using Client.Application.Contracts;
using Client.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Client.Application;

public static class RegisterDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(x => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        services.AddScoped<IDataService<Blog, int>, BlogService>();
        services.AddScoped<IDataService<BlogPost, int>, BlogPostService>();
        
        return services;
    }
}
