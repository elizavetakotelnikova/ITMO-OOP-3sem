using System;
using System.Collections.Generic;
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
        var listToRemove = new List<string>();
        foreach (string part in request.TokenizedLine)
        {
            commandPart += part;
            if (_allCommands.CommandsDictionary.TryGetValue(commandPart, out Func<ICommand>? commandDelegate))
            {
                request.Command = commandDelegate();
                listToRemove.Add(part);
                foreach (string item in listToRemove)
                {
                    request.TokenizedLine.Remove(item);
                }

                Next?.Handle(request);
                return;
            }

            listToRemove.Add(part);
            commandPart += " ";
        }

        throw new ArgumentException("Invalid command");
    }
}