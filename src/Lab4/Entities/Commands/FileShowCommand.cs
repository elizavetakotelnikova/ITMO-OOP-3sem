using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileShowCommand : ICommand
{
    public FileShowCommand()
    {
    }

    public FileShowCommand(string? path, ShowMode mode)
    {
        Path = path; // может надо добавить условие что путь не может быть пустой строкой
        Mode = mode;
    }

    public FileShowCommand(string? path)
    {
        Path = path; // может надо добавить условие что путь не может быть пустой строкой
    }

    public string? Path { get; set; }
    public ShowMode Mode { get; set; } = ShowMode.Console;

    public void SetArguments(IList<string> arguments)
    {
        if (arguments is null || arguments.Count < 1) return;
        Path = arguments[0];
        if (arguments.Count > 1)
        {
            if (arguments[1] == "console") Mode = ShowMode.Console;
        }
    }

    public void Execute(ExecutionContext context)
    {
        SetAddress(context);
        if (Path is null) throw new ArgumentNullException(nameof(context));
        switch (Mode)
        {
            case ShowMode.Console: // предполагаемое расширение в количестве способов вывода
                var file = new StreamReader(Path);
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
        if (context is null) throw new ArgumentNullException(nameof(context));
        var absolutePath = new Regex("[A-Z]{:}{\\}"); // сделать абстракцию на проверку абсолютности пути

        // if (Path is not null && absolutePath.IsMatch(Path)) context.CurrentPath = Address;
        if (Path is not null && !absolutePath.IsMatch(Path)) Path = context.CurrentPath + Path;
    }
}