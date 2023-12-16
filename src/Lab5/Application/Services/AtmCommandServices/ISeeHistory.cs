using ExecutionContext = DomainLayer.Models.ExecutionContext;

namespace Application.Services.ATMCommandServices;

public interface ISeeHistory
{
    void SeeHistory(ExecutionContext context);
}