using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileShowCommand : ICommand
{
    private IImplementFileSystem _receiver;
    private string? _path;
    private ShowMode _mode = ShowMode.Console;
    public FileShowCommand(IImplementFileSystem? receiver)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public FileShowCommand(IImplementFileSystem? receiver, string? path, ShowMode mode)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        _path = path;
        _mode = mode;
    }

    public FileShowCommand(IImplementFileSystem receiver, string? path)
    {
        _receiver = receiver;
        _path = path;
    }

    public bool AreValidArguments(IList<string> arguments)
    {
        if (arguments is null || arguments.Count < 1) return false;
        _path = arguments[0];
        return true;
    }

    public bool IsValidFlag(IList<string> flagArguments)
    {
        if (flagArguments is null) throw new ArgumentNullException(nameof(flagArguments));
        if (flagArguments.Count == 0) return true;
        switch (flagArguments[0])
        {
            case "-m":
                if (flagArguments[1] == "Console")
                {
                    _mode = ShowMode.Console;
                    return true;
                }

                break;
        }

        return false;
    }

    public void Execute(ExecutionContext context)
    {
        if (context?.CurrentPath is null || _path is null) throw new ArgumentNullException(nameof(context));
        _receiver.ShowFile(context, _path, _mode);
    }
}