using Application.Commands;
using Application.Services.ATMCommandServices;
using DomainLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using Ports.Input.Logging;

namespace Application.Services;

public class Configure
{
    private static ServiceProvider? _provider;

    public Configure(ServiceProvider provider)
    {
        _provider = provider;
    }

    public static Dictionary<string, Func<ICommand>> CommandsDictionary { get; } = new Dictionary<string, Func<ICommand>>()
    {
        ["log in"] = () => new LogInCommand(_provider?.GetService<ILogUser>()),
        ["disconnect"] = () => new DisconnectCommand(_provider?.GetService<IDisconnect>()),
        ["create"] = () => new CreateAccountCommand(_provider?.GetService<ICreateAccount>()),
        ["withdraw"] = () => new WithdrawCommand(_provider?.GetService<IWithdrawMoney>()),
        ["top up"] = () => new TopUpCommand(_provider?.GetService<ITopUp>()),
        ["show balance"] = () => new ShowBalanceCommand(_provider?.GetService<IShowBalance>()),
        ["see history"] = () => new SeeHistoryCommand(_provider?.GetService<ISeeHistory>()),
    };
}