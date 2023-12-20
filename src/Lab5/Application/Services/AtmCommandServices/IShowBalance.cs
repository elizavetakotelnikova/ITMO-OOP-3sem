using DomainLayer.Models;

namespace Application.Services.ATMCommandServices;

public interface IShowBalance
{
    public void ShowBalance(long accountId);
    public void ShowBalance(Account account);
}