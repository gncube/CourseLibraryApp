using Api;
using Api.Application;
using Api.Infrastructure;
using Blogifier.Application;
using Blogifier.Infrastructure;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) =>
    {
        services.AddInfrastructure(context.Configuration);
        services.AddApi();
        services.AddApplication(context.Configuration);

        services.AddApiApplication();
        services.AddApiInfrastructure(context.Configuration);
    })
    .Build();

host.Run();
