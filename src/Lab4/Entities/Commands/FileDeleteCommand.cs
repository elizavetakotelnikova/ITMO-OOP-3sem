using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileDeleteCommand : ICommand
{
    private string? _filePath;
    public FileDeleteCommand()
    {
    }

    public FileDeleteCommand(string? filePath)
    {
        _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
    }

    public bool AreValidArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 1) return false;
        _filePath = arguments[0];
        return true;
    }

    public bool IsValidFlag(IList<string> flagArguments)
    {
        if (flagArguments is null) throw new ArgumentNullException(nameof(flagArguments));
        if (flagArguments.Count >= 1) return false;
        return true;
    }

    public void Execute(ExecutionContext context)
    {
        if (context?.CurrentPath is null) throw new ArgumentNullException(nameof(context));
        if (_filePath is null) throw new ArgumentException("_filePath is not set");
        SetPath(context);
        if (!System.IO.File.Exists(@_filePath)) throw new ArgumentException("Wrong file path");
        System.IO.File.Delete(@_filePath);
    }

    private void SetPath(ExecutionContext context)
    {
        if (context is null || _filePath is null) throw new ArgumentNullException(nameof(context));
        var checker = new WindowsPathChecker();

        // if (Path is not null && absolutePath.IsMatch(Path)) context.CurrentPath = Address;
        if (!checker.IsValidAbsolutePath(_filePath)) _filePath = context.CurrentPath + _filePath;
    }
}