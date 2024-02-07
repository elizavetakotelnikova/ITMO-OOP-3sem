using Application.Services.Builders;
using DomainLayer.Models;
using DomainLayer.ValueObjects;
using Microsoft.Extensions.DependencyInjection;
using Ports.Repositories;
namespace Lab5;

public static class AdminSettings
{
    public static void CreateAdmin(IServiceProvider? provider, string password)
    {
        if (provider is null) throw new ArgumentNullException(nameof(provider));
        User admin = new UserBuilder().WithRole(UserRole.Admin).WithName("admin").WithPassword(password).Build();
        provider.GetService<IUsersRepository>()?.Add(admin);
    }
}