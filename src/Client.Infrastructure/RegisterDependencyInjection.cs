using Api.Domain;
using Blazored.LocalStorage;
using Client.Application.Contracts;
using Client.Infrastructure.DataServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Client.Infrastructure;

public static class RegisterDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOidcAuthentication(options =>
        {
            // Configure your authentication provider options here.
            // For more information, see https://aka.ms/blazor-standalone-auth
            configuration.Bind("Local", options.ProviderOptions);
        });

        services.AddSingleton(x => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        services.AddScoped<IDataService<Author, Guid>, AuthorDataService>();

        services.AddBlazoredLocalStorageAsSingleton();

        return services;
    }
}
