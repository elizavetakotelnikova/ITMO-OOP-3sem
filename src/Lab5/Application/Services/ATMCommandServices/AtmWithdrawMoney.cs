using DomainLayer.ValueObjects;
using Ports.Repositories;

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
        if (amount > account.Amount) throw new ArgumentException("Not enough money");
        account.Amount -= amount;
        amount *= -1;
        _repository.UpdateAmount(account, amount);
    }
}