namespace DomainLayer.Models;

public interface ICommand
{
    void Execute(ExecutionContext context);
    bool ValidateArguments(IList<string> arguments);
}