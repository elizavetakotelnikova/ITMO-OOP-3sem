using Application.Models;
using DomainLayer.ValueObjects;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Services.ATMCommandServices;

public interface ICreateAccount
{
    void CreateAccount(ExecutionContext context, Account account, User user);
}