using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public interface ICommand
{
    void Execute(ExecutionContext context);
    bool AreValidArguments(IList<string> arguments);
    bool IsValidFlag(IList<string> flagArguments);
}