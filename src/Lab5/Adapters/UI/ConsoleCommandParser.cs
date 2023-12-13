using Application.Services;
using DomainLayer.Models;
using Ports.Input;

namespace Adapters.UI;

public class ConsoleCommandParser : IParse
{
    public ICommand Parse()
    {
        IList<string> arguments = GetLine();
        ICommand? parsedCommand = DefineCommand(arguments);
        if (parsedCommand is null) throw new ArgumentException("Command is not parsed");
        return parsedCommand;
    }

    public IList<string> GetLine()
    {
        string? line = Console.ReadLine();
        if (line is null) return new List<string>();
        string[] arguments = line.Split(' ');
        return arguments.ToList();
    }

    private static ICommand? DefineCommand(IList<string> arguments)
    {
        if (arguments.Count == 0) return null;
        IChainLink commandHandler = new CommandHandler().AddNext(new ArgumentsHandler());
        var listArguments = arguments.ToList();
        var parsingRequest = new Request(null, listArguments);
        commandHandler.Handle(parsingRequest);
        return parsingRequest.Command;
    }
}