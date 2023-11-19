using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileShowCommand : ICommand
{
    private string? _path;
    private ShowMode _mode = ShowMode.Console;
    public FileShowCommand()
    {
    }

    public FileShowCommand(string? path, ShowMode mode)
    {
        _path = path;
        _mode = mode;
    }

    public FileShowCommand(string? path)
    {
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
        if (context?.CurrentPath is null) throw new ArgumentNullException(nameof(context));
        SetAddress(context);
        if (_path is null) throw new ArgumentNullException(nameof(context));
        switch (_mode)
        {
            case ShowMode.Console:
                var file = new StreamReader(_path);
                while (!file.EndOfStream)
                {
                    Console.WriteLine(file.ReadLine());
                }

                file.Close();
                break;
        }
    }

    private void SetAddress(ExecutionContext context)
    {
        if (context is null || _path is null) throw new ArgumentNullException(nameof(context));
        var checker = new WindowsPathChecker();
        if (!checker.IsValidAbsolutePath(_path)) _path = context.CurrentPath + _path;
    }
}