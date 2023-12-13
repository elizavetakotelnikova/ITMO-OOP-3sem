using Application.Services.ATMCommandServices;
using DomainLayer.Models;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Commands;

public class DisconnectCommand : ICommand
{
    private IDisconnect _receiver;

    public DisconnectCommand(IDisconnect? receiver)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public void Execute(ExecutionContext context)
    {
        if (context?.AtmUser is null) throw new ArgumentNullException(nameof(context));
        _receiver.Disconnect(context);
    }

    public bool ValidateArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        return arguments.Count == 0;
    }
}