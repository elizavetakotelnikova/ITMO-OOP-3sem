using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class FlagsHandler : ResponsibilityChainBase
{
    public override void Handle(ParsingRequest request)
    {
        if (request is null || request.Command is null) throw new ArgumentNullException(nameof(request));

        var flagsRegex = new Regex("{-}{-}[a-z]");
        var flagsList = new List<string>();
        foreach (string flagPart in request.TokenizedLine)
        {
            if (flagsRegex.IsMatch(flagPart)) flagsList.Clear();

            if (!request.Command.IsValidFlag(flagsList)) throw new ArgumentException("Invalid command");
        }

        if (!request.Command.IsValidFlag(flagsList)) throw new ArgumentException("Invalid command");
        Next?.Handle(request);
    }
}