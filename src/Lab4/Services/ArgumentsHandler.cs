using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class ArgumentsHandler : ResponsibilityChainBase
{
    public override void Handle(ParsingRequest request)
    {
        if (request is null || request.Command is null) throw new ArgumentNullException(nameof(request));

        var arguments = new List<string>();
        var flagsRegex = new Regex("[-][a-z]");
        foreach (string part in request.TokenizedLine)
        {
            if (flagsRegex.IsMatch(part)) break;
            arguments.Add(part);

            // request.TokenizedLine.Remove(part);
        }

        foreach (string item in arguments)
        {
            request.TokenizedLine.Remove(item);
        }

        if (request.Command.AreValidArguments(arguments))
        {
            Next?.Handle(request);
            return;
        }

        throw new ArgumentException("Invalid command"); // можно добавить именно про аргументы
    }
}