using Application.Models;
using DomainLayer.Models;
using Ports.Repositories;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Services.ATMCommandServices;

public class AtmCreateAccount : ICreateAccount
{
    private IAccountsRepository _accountsRepository;
    private IUsersRepository _usersRepository;

    public AtmCreateAccount(IAccountsRepository accountsRepository, IUsersRepository usersRepository)
    {
        _accountsRepository = accountsRepository;
        _usersRepository = usersRepository;
    }

    public void CreateAccount(ExecutionContext context, Account account, User user)
    {
        if (account is null) throw new ArgumentNullException(nameof(account));
        if (user is null) throw new ArgumentNullException(nameof(user));
        if (context is null) throw new ArgumentNullException(nameof(context));
        if (context.CurrentMode is UserRole.User) throw new ArgumentException("Operation cannot be done");
        bool existsUser = _usersRepository.ExistsId(user.Id);
        if (!existsUser) _usersRepository.Add(user);
        _accountsRepository.Add(account, user);
        if (context.AtmUser is null) throw new ArgumentNullException(nameof(context));
        context.AtmUser.Account = account;
    }
}