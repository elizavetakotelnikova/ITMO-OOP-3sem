using Application.Commands;
using Application.Services.ATMCommandServices;
using DomainLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using Ports.Input.Logging;
using Ports.Output;

namespace Application.Services;

public class ConfigureCommands
{
    private static ServiceProvider? _provider;

    public ConfigureCommands(ServiceProvider provider)
    {
        _provider = provider;
    }

    public static Dictionary<string, Func<ICommand>> CommandsDictionary { get; } = new Dictionary<string, Func<ICommand>>()
    {
        ["log in"] = () => new LogInCommand(_provider?.GetService<ILogUser>(), _provider?.GetService<IDisplayMessage>()),
        ["disconnect"] = () => new DisconnectCommand(_provider?.GetService<IDisconnect>()),
        ["create account"] = () => new CreateAccountCommand(_provider?.GetService<ICreateAccount>()),
        ["create user"] = () => new CreateUserCommand(_provider?.GetService<ICreateUser>()),
        ["withdraw"] = () => new WithdrawCommand(_provider?.GetService<IWithdrawMoney>()),
        ["top up"] = () => new TopUpCommand(_provider?.GetService<ITopUp>()),
        ["show balance"] = () => new ShowBalanceCommand(_provider?.GetService<IShowBalance>()),
        ["see history"] = () => new SeeHistoryCommand(_provider?.GetService<ISeeHistory>()),
    };
}