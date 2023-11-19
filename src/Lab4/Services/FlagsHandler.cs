using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class FlagsHandler : ResponsibilityChainBase
{
    public override void Handle(ParsingRequest request)
    {
        if (request?.Command is null) throw new ArgumentNullException(nameof(request));

        var flagsRegex = new Regex("[-][a-z]");
        var flagsList = new List<string>();
        foreach (string flagPart in request.TokenizedLine)
        {
            if (flagsRegex.IsMatch(flagPart))
            {
                if (flagsList.Count != 0 && !request.Command.IsValidFlag(flagsList))
                    throw new ArgumentException("Invalid command");
                flagsList.Clear();
                flagsList.Add(flagPart);
            }
            else
            {
                flagsList.Add(flagPart);
            }
        }

        if (!request.Command.IsValidFlag(flagsList)) throw new ArgumentException("Invalid command");
        Next?.Handle(request);
    }
}