using Adapters.UI;
using Application.Commands;
using Application.Models;
using Application.Services.Builders;
using DomainLayer.Models;
using Lab5;
using Microsoft.Extensions.DependencyInjection;
using Ports.Repositories;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
internal class Program
{
    public static void Main()
    {
        // configure
        IServiceProvider provider = ConfigurateProvider.Configurate();
        var parser = new ConsoleCommandParser();
        var appContext = new ExecutionContext(UserRole.User, new AtmUser(null, null));
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