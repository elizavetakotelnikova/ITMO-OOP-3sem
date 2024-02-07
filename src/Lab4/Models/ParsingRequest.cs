using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class ParsingRequest
{
    public ParsingRequest(ICommand? command, IList<string> tokenizedLine)
    {
        Command = command;
        TokenizedLine = tokenizedLine;
    }

    public IList<string> TokenizedLine { get; }
    public ICommand? Command { get; set; }
}