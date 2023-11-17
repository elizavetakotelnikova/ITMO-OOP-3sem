using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileDeleteCommand : ICommand
{
    public FileDeleteCommand()
    {
    }

    public FileDeleteCommand(string? filePath)
    {
        FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
    }

    public string? FilePath { get; set; }

    public void SetArguments(IList<string> arguments)
    {
        if (arguments is null || arguments.Count < 1) return;
        FilePath = arguments[0];
    }

    public void Execute(ExecutionContext context)
    {
        if (FilePath is null) throw new ArgumentException("FilePath is not set");
        SetPath(context);
        System.IO.File.Delete(FilePath);
    }

    private void SetPath(ExecutionContext context)
    {
        if (context is null || FilePath is null) throw new ArgumentNullException(nameof(context));
        var absolutePath = new Regex("[A-Z]{:}{\\}"); // сделать абстракцию на проверку абсолютности пути

        // if (Path is not null && absolutePath.IsMatch(Path)) context.CurrentPath = Address;
        if (!absolutePath.IsMatch(FilePath)) FilePath = context.CurrentPath + FilePath;
    }
}