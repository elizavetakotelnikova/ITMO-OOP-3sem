// See https://aka.ms/new-console-template for more information

using Adapters;
using Adapters.Persistence;
using Adapters.UI;
using Application.Migration;
using DomainLayer.Models;
using FluentMigrator.Runner; // using Itmo.Dev.Platform.Postgres.Extensions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute.Extensions;
using Ports.Input.Logging;

internal class Program
{
    public static void Main()
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
            .AddPresentationConsole();

        ServiceProvider provider = collection.BuildServiceProvider();
        IServiceScope scope = provider.CreateScope();
        /*IMigrationRunner runner = provider.GetRequiredService<IMigrationRunner>();
         runner.MigrateUp();*/
        scope.UseInfrastructureDataAccess();
        scope.Dispose();
        var configure = new Configure(provider.GetService<ILogUser>());
        ExecutionContext appContext = new ExecutionContext();
        var parser = new ConsoleCommandParser();
        var appContext = new ExecutionContext(null);
        var invoker = new CommandInvoker(appContext);

        // commands parsing
        while (true)
        {
            try
            {
                ICommand command = parser.Parse();
                invoker.Consume(command);
                if (command is DisconnectCommand) break;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                break;
            }
        }
    }
}