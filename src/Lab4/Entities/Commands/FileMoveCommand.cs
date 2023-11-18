using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileMoveCommand : ICommand
{
    public FileMoveCommand()
    {
    }

    public FileMoveCommand(string? sourcePath, string? destinationPath)
    {
        SourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        DestinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));
    }

    public string? SourcePath { get; set; }
    public string? DestinationPath { get; set; }

    public bool AreValidArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 2) return false;
        SourcePath = arguments[0];
        DestinationPath = arguments[1];
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
        if (SourcePath is null || DestinationPath is null) throw new ArgumentException("Path is not set");
        SetPath(context);
        if (!System.IO.File.Exists(SourcePath)) throw new ArgumentException("Wrong source path");
        System.IO.File.Move(SourcePath, DestinationPath);
    }

    private void SetPath(ExecutionContext context)
    {
        if (context is null || SourcePath is null || DestinationPath is null) throw new ArgumentNullException(nameof(context));
        var absolutePath = new Regex("[A-Z]{:}{\\}"); // сделать абстракцию на проверку абсолютности пути

        // if (Path is not null && absolutePath.IsMatch(Path)) context.CurrentPath = Address;
        if (!absolutePath.IsMatch(SourcePath)) SourcePath = context.CurrentPath + SourcePath;
        if (!absolutePath.IsMatch(DestinationPath)) DestinationPath = context.CurrentPath + DestinationPath;
    }
}