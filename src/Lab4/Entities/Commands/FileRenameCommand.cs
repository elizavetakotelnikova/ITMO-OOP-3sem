using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileRenameCommand : ICommand
{
    private IImplementFileSystem _receiver;
    private string? _filePath;
    private string? _newName;
    public FileRenameCommand(IImplementFileSystem? receiver)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public FileRenameCommand(IImplementFileSystem? receiver, string? filePath, string? newName)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        _newName = newName ?? throw new ArgumentNullException(nameof(newName));
    }

    public bool AreValidArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 2) return false;
        _filePath = arguments[0];
        _newName = arguments[1];
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
        if (_filePath is null || _newName is null) throw new ArgumentException("Parameters are not set");
        _receiver.RenameFile(context, _filePath, _newName);
    }
}