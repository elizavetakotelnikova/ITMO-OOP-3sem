using ExecutionContext = DomainLayer.Models.ExecutionContext;

namespace Application.Services.ATMCommandServices;

public interface IDisconnect
{
    void Disconnect(ExecutionContext context);
}