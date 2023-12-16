using Application.Models;
using Application.Services.ATMCommandServices;
using Application.Services.Builders;
using DomainLayer.Models;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Commands;

public class CreateAccountCommand : ICommand
{
    private ICreateAccount _receiver;
    private Account? _account;
    private User? _user;
    public CreateAccountCommand(ICreateAccount? receiver)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public CreateAccountCommand(ICreateAccount? receiver, Account? account, User? user)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        _account = account;
        _user = user;
    }

    public bool ValidateArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 2) return false;
        if (!int.TryParse(arguments[0], out int userId)) return false;
        if (!int.TryParse(arguments[1], out int pinCode)) return false;
        _user = new UserBuilder().WithId(userId).WithRole(UserRole.User).Build(); // вот тут надо подумать над админами
        _account = new AccountBuilder().WithPinCode(pinCode).WithAmount(0).Build();
        return true;
    }

    public void Execute(ExecutionContext context)
    {
        if (_account is null || _user is null || context is null) throw new ArgumentNullException(nameof(context));
        _receiver.CreateAccount(context, _account, _user);
    }
}