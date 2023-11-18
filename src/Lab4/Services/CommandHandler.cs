using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class CommandHandler : ResponsibilityChainBase
{
    private readonly ListOfCommands _allCommands = new ListOfCommands();
    public override void Handle(ParsingRequest request)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));
        if (request.TokenizedLine.Count == 0) throw new ArgumentException("Command is not set");

        string commandPart = string.Empty;
        foreach (string part in request.TokenizedLine)
        {
            commandPart += part;
            if (_allCommands.CommandsDictionary.TryGetValue(commandPart, out Func<ICommand>? commandDelegate))
            {
                request.Command = commandDelegate();
                request.TokenizedLine.Remove(part);
                Next?.Handle(request);
            }

            request.TokenizedLine.Remove(part);
            commandPart += " ";
        }

        throw new ArgumentException("Invalid command");
    }
}