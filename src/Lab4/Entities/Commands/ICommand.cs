using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface ICommand
{
    void Execute(ExecutionContext context);
    void SetArguments(IList<string> arguments);
}