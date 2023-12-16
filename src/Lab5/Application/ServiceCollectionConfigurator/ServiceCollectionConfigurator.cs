using Application.Services.ATMCommandServices;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ServiceCollectionConfigurator;

public static class ServiceCollectionConfigurator
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<ICreateAccount, AtmCreateAccount>();
        collection.AddScoped<ICreateUser, AtmCreateUser>();
        collection.AddScoped<IDisconnect, AtmDisconnect>();
        collection.AddScoped<ISeeHistory, AtmSeeHistory>();
        collection.AddScoped<IShowBalance, AtmShowBalance>();
        collection.AddScoped<ITopUp, AtmTopUp>();
        collection.AddScoped<IWithdrawMoney, AtmWithdrawMoney>();
        return collection;
    }
}