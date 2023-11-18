using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class ConnectCommand : ICommand
{
    public ConnectCommand()
    {
    }

    public ConnectCommand(string? address, Mode mode)
    {
        Address = address; // может надо добавить условие что путь не может быть пустой строкой
        Mode = mode;
    }

    public string? Address { get; set; }
    public Mode Mode { get; set; } = Mode.Local;

    public bool AreValidArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count < 1) return false;
        Address = arguments[0];
        return true;
    }

    public bool IsValidFlag(IList<string> flagArguments)
    {
        if (flagArguments is null) throw new ArgumentNullException(nameof(flagArguments));
        switch (flagArguments[0])
        {
            case "-m":
                if (flagArguments[1] == "Local")
                {
                    Mode = Mode.Local;
                    return true;
                }

                break;
        }

        return false;
    }

    public void SetAddress(ExecutionContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));
        var absolutePath = new Regex("[A-Z]{:}{\\}"); // сделать абстракцию на проверку абсолютности пути
        if (Address is not null && absolutePath.IsMatch(Address)) context.CurrentPath = Address;
        else context.CurrentPath += Address;
    }

    public void Execute(ExecutionContext context)
    {
        if (Address is null) return;
        SetAddress(context);
    }
}