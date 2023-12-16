using ExecutionContext = DomainLayer.Models.ExecutionContext;

namespace Application.Services.ATMCommandServices;

public interface ICreateUser
{
    void CreateUser(ExecutionContext context);
}