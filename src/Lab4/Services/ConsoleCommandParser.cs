using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class ConsoleCommandParser
{
    private ListOfCommands _allKnownCommands = new ListOfCommands();

    public static string[]? GetLine()
    {
        string? line = Console.ReadLine();
        if (line is null) return null; // надо посмотреть что возвращать
        string[] arguments = line.Split(' ');
        return arguments;
    }

    public ICommand? DefineCommand(string[]? arguments, IList<string> commandArgs)
    {
        if (arguments is null || commandArgs is null) return null; // this will never happen, but analyser makes me to write this;
        ICommand? currentCommand = null;
        if (arguments.Length >= 1 && _allKnownCommands.ListedCommands.TryGetValue(arguments[0], out Func<ICommand>? commandDelegate))
        {
            currentCommand = commandDelegate();
            foreach (string element in arguments.Skip(1))
            {
                commandArgs.Add(element);
            }
        }
        else
        {
            if (arguments.Length >= 2 && _allKnownCommands.ListedCommands.TryGetValue(arguments[0] + ' ' + arguments[1], out commandDelegate))
            {
                currentCommand = commandDelegate();
                foreach (string element in arguments.Skip(1).Skip(2))
                {
                    commandArgs.Add(element);
                }
            }
        }

        return currentCommand;
    }

    public ICommand? Parse()
    {
        string[]? arguments = GetLine();

        var commandArgs = new List<string>();
        ICommand? parsedCommand = DefineCommand(arguments, commandArgs);
        if (parsedCommand is null) return null;
        parsedCommand.SetArguments(commandArgs);
        return parsedCommand;
    }
}