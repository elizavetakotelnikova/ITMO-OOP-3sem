using DomainLayer.ValueObjects;

namespace Application.Repositories;

public interface IAccountsRepository
{
    Account? FindAccountByNumber(long accountId);
    void UpdateAmount(Account account, int amount);
}