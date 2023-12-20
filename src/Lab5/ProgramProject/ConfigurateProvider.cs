using Adapters;
using Application.Migration;
using Application.ServiceCollectionConfigurator;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5;

public static class ConfigurateProvider
{
    public static IServiceProvider Configurate()
    {
        // configure
        var collection = new ServiceCollection();

        collection
            .AddApplication()
            .AddInfrastructureDataAccess(configuration =>
            {
                configuration.Host = "localhost";
                configuration.Port = 6432;
                configuration.Username = "postgres";
                configuration.Password = "postgres";
                configuration.Database = "postgres";
                configuration.SslMode = "Prefer";
            })
            .AddAdapters();

        ServiceProvider provider = collection.BuildServiceProvider();
        IServiceScope scope = provider.CreateScope();
        scope.UseInfrastructureDataAccess();
        scope.Dispose();
        var configure = new ConfigureCommands(provider);
        return provider;
    }
}