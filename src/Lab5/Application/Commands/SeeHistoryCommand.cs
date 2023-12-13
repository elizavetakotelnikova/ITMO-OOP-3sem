using Application.Services.ATMCommandServices;
using DomainLayer.Models;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Commands;

public class SeeHistoryCommand : ICommand
{
    private ISeeHistory _receiver;

    public SeeHistoryCommand(ISeeHistory? receiver)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public bool ValidateArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count >= 1) return false;
        return true;
    }

    public void Execute(ExecutionContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));
        _receiver.SeeHistory(context);
    }
}