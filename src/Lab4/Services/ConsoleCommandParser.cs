using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class ConsoleCommandParser : IParseCommand
{
    public ICommand Parse()
    {
        string[]? arguments = GetLine();
        ICommand? parsedCommand = DefineCommand(arguments);
        if (parsedCommand is null) throw new ArgumentException("Command is not parsed");
        return parsedCommand;
    }

    public string[]? GetLine()
    {
        string? line = Console.ReadLine();
        if (line is null) return null; // надо посмотреть что возвращать
        string[] arguments = line.Split(' ');
        return arguments;
    }

    private static ICommand? DefineCommand(string[]? arguments)
    {
        if (arguments is null) return null;
        IChainLink commandHandler = new CommandHandler().
                AddNext(new ArgumentsHandler()).
                AddNext(new FlagsHandler());
        var listArguments = arguments.ToList();
        var parsingRequest = new ParsingRequest(null, listArguments);
        commandHandler.Handle(parsingRequest);
        return parsingRequest.Command;
    }
}