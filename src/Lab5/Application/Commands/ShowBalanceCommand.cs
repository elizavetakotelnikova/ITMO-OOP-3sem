using Application.Models;
using Application.Services.ATMCommandServices;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Commands;

public class ShowBalanceCommand : ICommand
{
    private IShowBalance _receiver;
    private long _requestedAccountId;

    public ShowBalanceCommand(IShowBalance? receiver)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public ShowBalanceCommand(IShowBalance? receiver, long accountId)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        _requestedAccountId = accountId;
    }

    public bool ValidateArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count > 1) return false;
        if (arguments.Count == 1)
            if (!long.TryParse(arguments[0], out _requestedAccountId)) return false;
        return true;
    }

    public void Execute(ExecutionContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));
        if (_requestedAccountId != 0)
        {
            if (context.CurrentMode != UserRole.Admin) return;
            _receiver.ShowBalance(_requestedAccountId);
            return;
        }

        if (context.AtmUser?.Account is null) throw new ArgumentNullException(nameof(context));
        _receiver.ShowBalance(context.AtmUser.Account);
    }
}