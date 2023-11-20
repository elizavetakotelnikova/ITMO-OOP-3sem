using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class ConnectCommand : ICommand
{
    private IImplementFileSystem _receiver;
    private string? _address;
    private Mode? _mode;
    public ConnectCommand(IImplementFileSystem? receiver)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public ConnectCommand(IImplementFileSystem? receiver, string? address, Mode mode)
    {
        if (receiver is null) throw new ArgumentNullException(nameof(receiver));
        _receiver = receiver;
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

        return false;
    }

    public void Execute(ExecutionContext context)
    {
        if (_address is null || _mode is null) throw new ArgumentNullException(nameof(context));
        _receiver.Connect(context, _mode, _address);
    }
}