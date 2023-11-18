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

    public bool AreValidArguments(IList<string> arguments)
    {
        if (arguments is null || arguments.Count < 1) return false;
        Path = arguments[0];
        return true;
    }

    public bool IsValidFlag(IList<string> flagArguments)
    {
        if (flagArguments is null) return true;
        switch (flagArguments[0])
        {
            case "-m":
                if (flagArguments[1] == "Console")
                {
                    Mode = ShowMode.Console;
                    return true;
                }

                break;
        }

        return false;
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