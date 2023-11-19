using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileCopyCommand : ICommand
{
    public FileCopyCommand()
    {
    }

    public FileCopyCommand(string? sourcePath, string? destinationPath)
    {
        SourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        DestinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));
    }

    public string? SourcePath { get; set; }
    public string? DestinationPath { get; set; }
    public bool AreValidArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 2) return false;
        SourcePath = arguments[0];
        DestinationPath = arguments[1];
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
        if (SourcePath is null || DestinationPath is null) throw new ArgumentException("Path is not set");
        SetPath(context);
        if (!System.IO.File.Exists(@SourcePath)) throw new ArgumentException("Wrong source path");
        System.IO.File.Copy(@SourcePath, @DestinationPath);
    }

    private void SetPath(ExecutionContext context)
    {
        if (context?.CurrentPath is null || SourcePath is null || DestinationPath is null) throw new ArgumentNullException(nameof(context));
        var checker = new WindowsPathChecker();

        // if (Path is not null && absolutePath.IsMatch(Path)) context.CurrentPath = Address;
        if (!checker.IsValidAbsolutePath(SourcePath)) SourcePath = context.CurrentPath + SourcePath;
        if (!checker.IsValidAbsolutePath(DestinationPath)) DestinationPath = context.CurrentPath + DestinationPath;
        DestinationPath += "\\" + System.IO.Path.GetFileName(SourcePath);
    }
}