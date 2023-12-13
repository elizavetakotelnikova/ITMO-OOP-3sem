using Application.Services.ATMCommandServices;
using DomainLayer.Models;
using ExecutionContext = DomainLayer.Models.ExecutionContext;

namespace Application.Commands;
public class TopUpCommand : ICommand
{
    private ITopUp _receiver;
    private int _amount;

    public TopUpCommand(ITopUp? receiver)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public TopUpCommand(ITopUp? receiver, int amount)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        _amount = amount;
    }

    public bool ValidateArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 1) return false;
        if (int.TryParse(arguments[0], out _amount)) return true;
        return false;
    }

    public void Execute(ExecutionContext context)
    {
        if (_amount == 0) throw new ArgumentException("Amount is not set");
        if (context?.AtmUser is null || context.AtmUser.Account is null) throw new ArgumentNullException(nameof(context));
        _receiver.TopUp(context.AtmUser.Account, _amount);
    }
}