using DomainLayer.Models;
using DomainLayer.ValueObjects;
using Ports.Input.Logging;
using Ports.Output;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Application.Commands;

public class LogInCommand : ICommand
{
    private readonly ILogUser _logger;
    private readonly IDisplayMessage _display;
    private IList<string> _arguments = new List<string>();
    private UserRole _role;

    public LogInCommand(ILogUser? logger, IDisplayMessage? display)
    {
        if (logger is null) throw new ArgumentNullException(nameof(logger));
        if (display is null) throw new ArgumentNullException(nameof(display));
        _logger = logger;
        _display = display;
    }

    public LogInCommand(ILogUser logger, IDisplayMessage display, UserRole role, IList<string> arguments)
    {
        _logger = logger;
        _display = display;
        _role = role;
        _arguments = arguments;
    }

    public bool ValidateArguments(IList<string> arguments)
    {
        if (arguments is null) return false;
        if (!UserRole.TryParse(arguments[0], true, out _role)) return false;
        return true;
    }

    public void Execute(ExecutionContext context)
    {
        if (_logger.LogIn(_role, context) == LogInResult.NotFound) throw new ArgumentException("Wrong pinCode");
        _display.DisplayMessage("Successful login");
    }
}