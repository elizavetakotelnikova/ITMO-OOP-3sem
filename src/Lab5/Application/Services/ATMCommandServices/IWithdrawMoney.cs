using DomainLayer.ValueObjects;

namespace Application.Services.ATMCommandServices;

public interface IWithdrawMoney
{
    void WithdrawMoney(Account account, int amount);
}