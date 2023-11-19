using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileDeleteCommand : ICommand
{
    public FileDeleteCommand()
    {
    }

    public FileDeleteCommand(string? filePath)
    {
        FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
    }

    public string? FilePath { get; set; }

    public bool AreValidArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 1) return false;
        FilePath = arguments[0];
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
        if (FilePath is null) throw new ArgumentException("FilePath is not set");
        SetPath(context);
        if (!System.IO.File.Exists(@FilePath)) throw new ArgumentException("Wrong file path");
        System.IO.File.Delete(@FilePath);
    }

    private void SetPath(ExecutionContext context)
    {
        if (context is null || FilePath is null) throw new ArgumentNullException(nameof(context));
        var checker = new WindowsPathChecker();

        // if (Path is not null && absolutePath.IsMatch(Path)) context.CurrentPath = Address;
        if (!checker.IsValidAbsolutePath(FilePath)) FilePath = context.CurrentPath + FilePath;
    }
}