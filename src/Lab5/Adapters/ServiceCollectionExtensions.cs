using Adapters.Persistence;
using Adapters.UI;
using Application.Extensions;
using Application.Migration;
using Application.Models;
using Application.Repositories;
using Application.Services.ATMCommandServices;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Ports.Input.Logging;
using Ports.Output;
using Ports.Repositories;

namespace Adapters;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<ILogUser, LogUserService>();

        collection.AddScoped<IUsersRepository, DataBaseUserRepository>();
        collection.AddScoped<IAccountsRepository, DataBaseAccountRepository>();
        collection.AddScoped<ITransactionsRepository, DataBaseTransactionsRepository>();

        return collection;
    }

    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        /*collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();*/
        collection.AddScoped<ICreateAccount, AtmCreateAccountService>();
        collection.AddScoped<IDisconnect, AtmDisconnect>();
        collection.AddScoped<ISeeHistory, AtmSeeHistory>();
        collection.AddScoped<IShowBalance, AtmShowBalance>();
        collection.AddScoped<ITopUp, AtmTopUpService>();
        collection.AddScoped<IWithdrawMoney, AtmWithdrawMoney>();
        collection.AddScoped<IDisplayMessage, ConsoleDisplayer>();
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