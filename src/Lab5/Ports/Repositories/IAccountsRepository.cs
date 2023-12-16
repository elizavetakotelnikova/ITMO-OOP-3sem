using DomainLayer.Models;
namespace Ports.Repositories;

public interface IAccountsRepository
{
    Account? FindAccountByAccountId(long accountId);
    User? FindUserByAccountId(long? accountId);
    void UpdateAmount(Account account, int amount);
    void Add(Account account);
    void Delete(Account account);
}