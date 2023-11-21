using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileDeleteCommand : ICommand
{
    private IImplementFileSystem _receiver;
    private string? _filePath;
    public FileDeleteCommand(IImplementFileSystem? receiver)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public FileDeleteCommand(IImplementFileSystem? receiver, string? filePath)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
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
        _receiver.DeleteFile(context, _filePath);
    }
}