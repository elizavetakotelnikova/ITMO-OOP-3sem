using DomainLayer.ValueObjects;
using Ports.Output;
using Ports.Repositories;

namespace Application.Services.ATMCommandServices;

public class AtmShowBalance : IShowBalance
{
    private readonly IDisplayMessage _display;
    private readonly IAccountsRepository _repository;

    public AtmShowBalance(IDisplayMessage display, IAccountsRepository repository)
    {
        _display = display;
        _repository = repository;
    }

    public void ShowBalance(Account account)
    {
        if (account is null) throw new ArgumentNullException(nameof(account));
        _display.DisplayMessage($"Account has {account.Amount}$");
    }

    public void ShowBalance(long accountId)
    {
        Account account = _repository.FindAccountByNumber(accountId) ??
                          throw new ArgumentException("Account not found");
        _display.DisplayMessage($"Account has {account.Amount}$");
    }
}