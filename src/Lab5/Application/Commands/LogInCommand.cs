using Application.Models;
using Ports.Input.Logging;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Commands;

public class LogInCommand : ICommand
{
    private ILogUser _logger;
    private IList<string> _arguments = new List<string>();
    private UserRole _role;

    public LogInCommand(ILogUser? logger)
    {
        if (logger is null) throw new ArgumentNullException(nameof(logger));
        _logger = logger;
    }

    public LogInCommand(ILogUser logger, UserRole role, IList<string> arguments)
    {
        _logger = logger;
        _role = role;
        _arguments = arguments;
    }

    public bool ValidateArguments(IList<string> arguments)
    {
        if (arguments is null) return false;
        if (!UserRole.TryParse(arguments[0], out _role)) return false;
        return true;
    }

    public void Execute(ExecutionContext context) // или контекст
    {
        _logger.LogIn(_role, context);
    }
}