using Application.Services.ATMCommandServices;
using DomainLayer.Models;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Commands;

public class CreateUserCommand : ICommand
{
    private readonly ICreateUser _receiver;
    public CreateUserCommand(ICreateUser? receiver)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public bool ValidateArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 0) return false;
        return true;
    }

    public void Execute(ExecutionContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));
        _receiver.CreateUser(context);
    }
}