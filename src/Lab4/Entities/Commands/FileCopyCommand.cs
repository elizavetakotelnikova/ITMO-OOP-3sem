using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileCopyCommand : ICommand
{
    private string? _sourcePath;
    private string? _destinationPath;
    public FileCopyCommand()
    {
    }

    public FileCopyCommand(string? sourcePath, string? destinationPath)
    {
        _sourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        _destinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));
    }

    public bool AreValidArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 2) return false;
        _sourcePath = arguments[0];
        _destinationPath = arguments[1];
        return true;
    }

    public bool IsValidFlag(IList<string> flagArguments)
    {
        if (flagArguments is null) throw new ArgumentNullException(nameof(flagArguments));
        return flagArguments.Count == 0;
    }

    public void Execute(ExecutionContext context)
    {
        if (_sourcePath is null || _destinationPath is null) throw new ArgumentException("Path is not set");
        SetPath(context);
        if (!System.IO.File.Exists(@_sourcePath)) throw new ArgumentException("Wrong source path");
        System.IO.File.Copy(@_sourcePath, @_destinationPath);
    }

    private void SetPath(ExecutionContext context)
    {
        if (context?.CurrentPath is null || _sourcePath is null || _destinationPath is null) throw new ArgumentNullException(nameof(context));
        var checker = new WindowsPathChecker();

        if (!checker.IsValidAbsolutePath(_sourcePath)) _sourcePath = context.CurrentPath + _sourcePath;
        if (!checker.IsValidAbsolutePath(_destinationPath)) _destinationPath = context.CurrentPath + _destinationPath;
        _destinationPath += "\\" + System.IO.Path.GetFileName(_sourcePath);
    }
}