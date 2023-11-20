using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileMoveCommand : ICommand
{
    private IImplementFileSystem _receiver;
    private string? _sourcePath;
    private string? _destinationPath;
    public FileMoveCommand(IImplementFileSystem? receiver)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public FileMoveCommand(IImplementFileSystem? receiver, string? sourcePath, string? destinationPath)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
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
        if (context?.CurrentPath is null) throw new ArgumentNullException(nameof(context));
        if (_sourcePath is null || _destinationPath is null) throw new ArgumentException("Path is not set");
        _receiver.MoveFile(context, _sourcePath, _destinationPath);
    }
}