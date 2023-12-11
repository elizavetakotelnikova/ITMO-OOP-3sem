using Application.Models;

namespace DomainLayer.Models;

public class CommandsHistory
{
    private readonly IList<ICommand> _commands = new List<ICommand>();

    public IList<ICommand> Commands => _commands;

    public void AddCommand(ICommand command)
    {
        _commands.Insert(0, command);
    }
}