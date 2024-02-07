using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Services.ATMCommandServices;

public interface ICreateAccount
{
    void CreateAccount(ExecutionContext context, int pinCode, long userId);
}