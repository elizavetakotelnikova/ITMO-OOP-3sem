using Application.Services.ATMCommandServices;
using DomainLayer.Models;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Commands;

public class CreateUserCommand : ICommand
{
    private readonly ICreateUser _receiver;
    private string? _username;
    public CreateUserCommand(ICreateUser? receiver)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public bool ValidateArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count > 1) return false;
        if (arguments.Count == 1) _username = arguments[0];
        return true;
    }

    public void Execute(ExecutionContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));
        _receiver.CreateUser(context, _username);
    }
}