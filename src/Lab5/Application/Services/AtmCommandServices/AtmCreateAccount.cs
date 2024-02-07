using Application.Services.Builders;
using DomainLayer.Models;
using DomainLayer.ValueObjects;
using Ports.Repositories;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Services.ATMCommandServices;

public class AtmCreateAccount : ICreateAccount
{
    private readonly IAccountsRepository _accountsRepository;
    private readonly IUsersRepository _usersRepository;

    public AtmCreateAccount(IAccountsRepository accountsRepository, IUsersRepository usersRepository)
    {
        _accountsRepository = accountsRepository;
        _usersRepository = usersRepository;
    }

    public void CreateAccount(ExecutionContext context, int pinCode, long userId)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));
        if (context.CurrentMode is UserRole.User) throw new ArgumentException("Operation cannot be done. You should be an admin to do this");
        bool existsUser = _usersRepository.ExistsId(userId);
        if (!existsUser) throw new ArgumentException("User not found");
        Account account = new AccountBuilder().WithPinCode(pinCode).WithAmount(0).WithUserId(userId).Build();
        _accountsRepository.Add(account);
        if (context.AtmUser is null) throw new ArgumentNullException(nameof(context));
        context.AtmUser.Account = account;
    }
}