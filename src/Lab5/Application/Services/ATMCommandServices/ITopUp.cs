using DomainLayer.ValueObjects;

namespace Application.Services.ATMCommandServices;

public interface ITopUp
{
    public void TopUp(Account account, int amount);
}