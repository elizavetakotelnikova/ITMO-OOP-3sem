using Application.Repositories;
using DomainLayer.ValueObjects;

namespace Application.Services.ATMCommandServices;

public class AtmTopUpService : ITopUp
{
    private IAccountsRepository _repository;

    public AtmTopUpService(IAccountsRepository repository)
    {
        _repository = repository;
    }

    public void TopUp(Account account, int amount)
    {
        if (account is null) throw new ArgumentNullException(nameof(account));
        account.Amount += amount;
        _repository.UpdateAmount(account, amount);
    }
}