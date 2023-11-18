using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public record Request
{
    public Request(ICommand? command, ExecutionContext context)
    {
        Command = command;
        Context = context;
    }

    public ICommand? Command { get; set; }
    public ExecutionContext Context { get; set; }
}