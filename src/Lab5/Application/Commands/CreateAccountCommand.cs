using Application.Services.ATMCommandServices;
using DomainLayer.Models;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Commands;

public class CreateAccountCommand : ICommand
{
    private readonly ICreateAccount _receiver;
    private int _accountPinCode;
    private long _userId;
    public CreateAccountCommand(ICreateAccount? receiver)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public CreateAccountCommand(ICreateAccount? receiver, int accountPinCode, long userId)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        _accountPinCode = accountPinCode;
        _userId = userId;
    }

    public bool ValidateArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 2) return false;
        if (!int.TryParse(arguments[0], out int userId)) return false;
        if (!int.TryParse(arguments[1], out int pinCode)) return false;
        _userId = userId;
        _accountPinCode = pinCode;
        return true;
    }

    public void Execute(ExecutionContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));
        if (_accountPinCode == 0 || _userId == 0) throw new ArgumentException("Null arguments");
        _receiver.CreateAccount(context, _accountPinCode, _userId);
    }
}