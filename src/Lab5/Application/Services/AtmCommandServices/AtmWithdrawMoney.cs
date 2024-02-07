using DomainLayer.Models;
using Ports.Repositories;

namespace Application.Services.ATMCommandServices;

public class AtmWithdrawMoney : IWithdrawMoney
{
    private readonly IAccountsRepository _repository;

    public AtmWithdrawMoney(IAccountsRepository repository)
    {
        _repository = repository;
    }

    public void WithdrawMoney(Account account, int amount)
    {
        if (account is null) throw new ArgumentException("Seems, you haven't logged in any account yet");
        if (amount > account.Balance) throw new ArgumentException("Not enough money");
        account.Balance -= amount;
        amount *= -1;
        _repository.UpdateAmount(account, amount);
    }
}