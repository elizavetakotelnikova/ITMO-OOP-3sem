using Application.Repositories;
using DomainLayer.ValueObjects;

namespace Application.Services.ATMCommandServices;

public class AtmWithdrawMoney : IWithdrawMoney
{
    private IAccountsRepository _repository;

    public AtmWithdrawMoney(IAccountsRepository repository)
    {
        _repository = repository;
    }

    public void WithdrawMoney(Account account, int amount)
    {
        if (account is null) throw new ArgumentNullException(nameof(account));
        if (amount > account.Amount) throw new ArgumentException("Operation cannot be done");
        account.Amount -= amount;
        _repository.UpdateAmount(account, amount);
    }
}