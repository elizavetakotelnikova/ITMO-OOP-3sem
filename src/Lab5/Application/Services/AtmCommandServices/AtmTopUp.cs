using DomainLayer.Models;
using Ports.Repositories;

namespace Application.Services.ATMCommandServices;

public class AtmTopUp : ITopUp
{
    private IAccountsRepository _repository;

    public AtmTopUp(IAccountsRepository repository)
    {
        _repository = repository;
    }

    public void TopUp(Account account, int amount)
    {
        if (account is null) throw new ArgumentNullException(nameof(account));
        account.Balance += amount;
        _repository.UpdateAmount(account, amount);
    }
}