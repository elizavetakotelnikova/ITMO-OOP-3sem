using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class CommandInvoker
{
    private readonly ExecutionContext _context;

    public CommandInvoker(ExecutionContext context)
    {
        _context = context;
    }

    public void Consume(ICommand command)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));
        command.Execute(_context);
    }
}