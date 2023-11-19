using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class ConnectCommand : ICommand
{
    /*private readonly IDictionary<string, string?> _allowedFlags = new Dictionary<string, string?>()
    {
        ["-m"] = null,
    };*/
    private string? _address;
    private Mode? _mode;
    public ConnectCommand()
    {
    }

    public ConnectCommand(string? address, Mode mode)
    {
        _address = address; // может надо добавить условие что путь не может быть пустой строкой
        _mode = mode;
    }

    public bool AreValidArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count < 1) return false;
        _address = arguments[0];
        return true;
    }

    public bool IsValidFlag(IList<string> flagArguments)
    {
        if (flagArguments is null) throw new ArgumentNullException(nameof(flagArguments));
        if (flagArguments.Count == 0) return true;
        switch (flagArguments[0])
        {
            case "-m":
                if (flagArguments[1] == "local")
                {
                    _mode = Mode.Local;
                    return true;
                }

                break;
        }

        /*if (!_allowedFlags.TryGetValue(flagArguments[0], out string? exists)) return false;
        if (exists is not null) return false;
        _allowedFlags[flagArguments[0]] = flagArguments[1];
        return true;*/
        return false;
    }

    public void SetAddress(ExecutionContext context)
    {
        if (context is null || _address is null) throw new ArgumentNullException(nameof(context));
        var checker = new WindowsPathChecker();
        if (checker.IsValidAbsolutePath(_address)) context.CurrentPath = _address;
        else context.CurrentPath += _address;
    }

    public void Execute(ExecutionContext context)
    {
        if (_address is null || _mode is null) throw new ArgumentNullException(nameof(context));
        SetAddress(context);
    }
}