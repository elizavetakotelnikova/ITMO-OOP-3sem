using Adapters.UI;
using Application.Commands;
using Application.Services.Builders;
using DomainLayer.Models;
using DomainLayer.ValueObjects;
using Lab5;
using Microsoft.Extensions.DependencyInjection;
using Ports.Repositories;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
internal class Program
{
    public static void Main()
    {
        // configure for live-testing (this part can be deleted)
        IServiceProvider provider = ConfigurateProvider.Configurate();
        var parser = new ConsoleCommandParser();
        var appContext = new ExecutionContext(UserRole.User, new AtmUser(null, null));
        var invoker = new CommandInvoker(provider?.GetService<ITransactionsRepository>(), appContext);
        AdminSettings.CreateAdmin(provider, "12347");
        User secondUser = new UserBuilder().WithRole(UserRole.User).Build();
        provider?.GetService<IUsersRepository>()?.Add(secondUser);
        Account firstAccount = new AccountBuilder().WithPinCode(1234).WithUserId(secondUser.Id).Build();
        provider?.GetService<IAccountsRepository>()?.Add(firstAccount);

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

        /*provider?.GetService<ITransactionsRepository>()?.DeleteByAccountId(firstAccount.Id);
        provider?.GetService<IAccountsRepository>()?.Delete(firstAccount);
        provider?.GetService<IUsersRepository>()?.Delete(secondUser);*/
    }
}