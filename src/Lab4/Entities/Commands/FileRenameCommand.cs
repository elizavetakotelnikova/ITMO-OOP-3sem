using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileRenameCommand : ICommand
{
    private string? _filePath;
    private string? _newName;
    public FileRenameCommand()
    {
    }

    public FileRenameCommand(string? filePath, string? newName)
    {
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
        SetPath(context); // посмотреть про два варианта написания пути директории
        if (!System.IO.File.Exists(@_filePath)) throw new ArgumentException("Wrong source path");
        System.IO.File.Move(@_filePath, System.IO.Path.GetDirectoryName(@_filePath) + '\\' + _newName);
    }

    private void SetPath(ExecutionContext context)
    {
        if (context is null || _filePath is null) throw new ArgumentNullException(nameof(context));
        var checker = new WindowsPathChecker();
        if (!checker.IsValidAbsolutePath(_filePath)) _filePath = context.CurrentPath + _filePath;
    }
}