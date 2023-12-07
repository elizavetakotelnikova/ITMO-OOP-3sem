using Adapters.Persistence;
using Application.Extensions;
using Application.Migration;
using Application.Models;
using Application.Repositories;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Ports.Input.Logging;

namespace Adapters;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<ILogUser, LogUserService>();

        collection.AddScoped<User>();
        collection.AddScoped<User>(
            p => p.GetRequiredService<User>());

        return collection;
    }

    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        /*collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();*/

        return collection;
    }

    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(Initial).Assembly);

        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddScoped<IUsersRepository, DataBaseUserRepository>();

        return collection;
    }
}