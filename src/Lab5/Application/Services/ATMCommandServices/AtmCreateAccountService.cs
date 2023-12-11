using Application.Models;
using Application.Repositories;
using DomainLayer.ValueObjects;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Services.ATMCommandServices;

public class AtmCreateAccountService : ICreateAccount
{
    private IAccountsRepository _accountsRepository;
    private IUsersRepository _usersRepository;

    public AtmCreateAccountService(IAccountsRepository accountsRepository, IUsersRepository usersRepository)
    {
        _accountsRepository = accountsRepository;
        _usersRepository = usersRepository;
    }

    public void CreateAccount(ExecutionContext context, Account account, User user)
    {
        if (account is null) throw new ArgumentNullException(nameof(account));
        if (user is null) throw new ArgumentNullException(nameof(user));
        if (context?.CurrentMode is UserRole.User) throw new ArgumentException("Operation cannot be done");
        account.AccountId = _accountsRepository.SelectNextAccountId();
        bool existsUser = _usersRepository.ExistsId(user.Id);
        if (!existsUser) _usersRepository.Add(user);
        _accountsRepository.Add(account, user);
    }
}