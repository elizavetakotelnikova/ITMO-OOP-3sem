using Adapters.Persistence;
using Adapters.UI;
using Application.Extensions;
using Application.Migration;
using Application.Models;
using DomainLayer.ValueObjects;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Ports.Input;
using Ports.Input.Logging;
using Ports.Output;
using Ports.Repositories;

namespace Adapters;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAdapters(this IServiceCollection collection)
    {
        collection.AddScoped<ILogUser, LogUserService>();
        collection.AddScoped<IAuthorizeUser, LogUserService>();
        collection.AddScoped<AtmUser, AtmUser>();
        collection.AddScoped<Account, Account>();
        collection.AddScoped<IUsersRepository, DataBaseUserRepository>();
        collection.AddScoped<IAccountsRepository, DataBaseAccountRepository>();
        collection.AddScoped<ITransactionsRepository, DataBaseTransactionsRepository>();
        collection.AddScoped<IDisplayMessage, ConsoleDisplayer>();
        collection.AddScoped<IParse, ConsoleCommandParser>();
        return collection;
    }

    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(Initial).Assembly);

        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        return collection;
    }
}