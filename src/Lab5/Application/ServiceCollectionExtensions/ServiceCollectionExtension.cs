using Application.Services.ATMCommandServices;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ServiceCollectionExtensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        /*collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();*/
        collection.AddScoped<ICreateAccount, AtmCreateAccountService>();
        collection.AddScoped<IDisconnect, AtmDisconnect>();
        collection.AddScoped<ISeeHistory, AtmSeeHistory>();
        collection.AddScoped<IShowBalance, AtmShowBalance>();
        collection.AddScoped<ITopUp, AtmTopUpService>();
        collection.AddScoped<IWithdrawMoney, AtmWithdrawMoney>();
        return collection;
    }
}