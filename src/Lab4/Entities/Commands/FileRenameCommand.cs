using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileRenameCommand : ICommand
{
    public FileRenameCommand()
    {
    }

    public FileRenameCommand(string? filePath, string? newName)
    {
        FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        NewName = newName ?? throw new ArgumentNullException(nameof(newName));
    }

    public string? FilePath { get; set; }

    public string? NewName { get; set; }

    public bool AreValidArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 2) return false;
        FilePath = arguments[0];
        NewName = arguments[1];
        return true;
    }

    public bool IsValidFlag(IList<string> flagArguments)
    {
        if (flagArguments is null) throw new ArgumentNullException(nameof(flagArguments));
        if (flagArguments.Count >= 1) return false;
        return true;
    }

    public void Execute(ExecutionContext context)
    {
        if (FilePath is null || NewName is null) throw new ArgumentException("Parameters are not set");
        SetPath(context); // посмотреть про два варианта написания пути директории
        System.IO.File.Move(FilePath, System.IO.Path.GetDirectoryName(FilePath) + '\\' + NewName);
    }

    private void SetPath(ExecutionContext context)
    {
        if (context is null || FilePath is null) throw new ArgumentNullException(nameof(context));
        var absolutePath = new Regex("[A-Z]{:}{\\}"); // сделать абстракцию на проверку абсолютности пути

        // if (Path is not null && absolutePath.IsMatch(Path)) context.CurrentPath = Address;
        if (!absolutePath.IsMatch(FilePath)) FilePath = context.CurrentPath + FilePath;
    }
}