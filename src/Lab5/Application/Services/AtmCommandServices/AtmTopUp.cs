using DomainLayer.Models;
using Ports.Repositories;

namespace Application.Services.ATMCommandServices;

public class AtmTopUp : ITopUp
{
    private readonly IAccountsRepository _repository;

    public AtmTopUp(IAccountsRepository repository)
    {
        _repository = repository;
    }

    public void TopUp(Account account, int amount)
    {
        if (account is null) throw new ArgumentException("Seems, you haven't logged in any account yet");
        account.Balance += amount;
        _repository.UpdateAmount(account, amount);
    }
}