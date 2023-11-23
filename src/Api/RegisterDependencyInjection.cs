using Microsoft.Extensions.DependencyInjection;

namespace Api;
public static class RegisterDependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        return services;
    }
}
