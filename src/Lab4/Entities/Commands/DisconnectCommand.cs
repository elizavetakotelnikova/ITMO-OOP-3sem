using System;
using System.Collections.Generic;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class DisconnectCommand : ICommand
{
    public void SetArguments(IList<string> arguments)
    {
        if (arguments is null) return;
    }

    public void Execute(ExecutionContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));
        context.CurrentPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
    }
}