using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class CommandInvoker
{
    public CommandInvoker(ExecutionContext context)
    {
        Context = context;
    }

    public ExecutionContext Context { get; }
    public void Consume(ICommand command)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));
        command.Execute(Context);
    }
}