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

    public void SetArguments(IList<string> arguments)
    {
        if (arguments is null || arguments.Count < 1) return;
        Address = arguments[0];
        if (arguments.Count > 1)
        {
            if (arguments[1] == "local") Mode = Mode.Local;
        }
    }
}