using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Models;

public interface ICommand
{
    void Execute(ExecutionContext context);
    bool ValidateArguments(IList<string> arguments);
}