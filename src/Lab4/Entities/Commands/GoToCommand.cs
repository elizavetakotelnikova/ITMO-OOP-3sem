using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class GoToCommand : ICommand
{
    private string? _path;
    public GoToCommand()
    {
    }

    public GoToCommand(string? path)
    {
        _path = path;
    }

    public bool AreValidArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 1) return false;
        _path = arguments[0];
        return true;
    }

    public bool IsValidFlag(IList<string> flagArguments)
    {
        if (flagArguments is null) throw new ArgumentNullException(nameof(flagArguments));
        return flagArguments.Count == 0;
    }

    public void SetAddress(ExecutionContext context)
    {
        if (context is null || _path is null) throw new ArgumentNullException(nameof(context));
        var checker = new WindowsPathChecker();
        if (checker.IsValidAbsolutePath(_path)) context.CurrentPath = _path;
        else context.CurrentPath += _path;
    }

    public void Execute(ExecutionContext context)
    {
        if (context?.CurrentPath is null) throw new ArgumentNullException(nameof(context));
        if (_path is null) throw new ArgumentException("Path is not set");
        SetAddress(context);
    }
}