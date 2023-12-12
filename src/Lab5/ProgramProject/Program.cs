// See https://aka.ms/new-console-template for more information

using Adapters;
using Adapters.UI;
using Application.Commands;
using Application.Migration;
using Application.Models;
using Application.Repositories;
using Application.Services.Builder;
using DomainLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using Ports.Repositories;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
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
        var configure = new Configure(provider);
        var parser = new ConsoleCommandParser();
        var appContext = new ExecutionContext(UserRole.User, null);
        var invoker = new CommandInvoker(provider?.GetService<ITransactionsRepository>(), appContext);
        var userBuilder = new UserBuilder();
        provider?.GetService<IUsersRepository>()?.Add(userBuilder.WithRole(UserRole.Admin).WithName("admin").WithPassword("12345").Build());
        User user = new UserBuilder().WithRole(UserRole.User).Build();
        provider?.GetService<IUsersRepository>()?.Add(user);
        provider?.GetService<IAccountsRepository>()?.Add(new AccountBuilder().WithPinCode(1234).Build(), user);

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