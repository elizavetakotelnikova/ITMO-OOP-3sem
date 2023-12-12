using Application.Models;
using DomainLayer.Models;
using DomainLayer.ValueObjects;
namespace Application.Repositories;

public interface IAccountsRepository
{
    Account? FindAccountByNumber(long accountId);
    void UpdateAmount(Account account, int amount);
    void Add(Account account, User user);
    void Add(AvailableAccountInfo account, User user);
}