using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class GoToCommand : ICommand
{
    public GoToCommand()
    {
    }

    public GoToCommand(string? path)
    {
        Path = path; // может надо добавить условие что путь не может быть пустой строкой
    }

    public string? Path { get; set; }

    public void SetArguments(IList<string> arguments)
    {
        if (arguments is null || arguments.Count < 1) return;
        Path = arguments[0];
    }

    public void SetAddress(ExecutionContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));
        var absolutePath = new Regex("[A-Z]{:}{\\}"); // сделать абстракцию на проверку абсолютности пути
        if (Path is not null && absolutePath.IsMatch(Path)) context.CurrentPath = Path;
        else context.CurrentPath += Path;
    }

    public void Execute(ExecutionContext context)
    {
        if (Path is null) throw new ArgumentException("Path is not set");
        SetAddress(context);
    }
}