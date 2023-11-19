using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class TreeListCommand : ICommand
{
    /*private IDictionary<string, string> _allowedFlags = new Dictionary<string, string>()
    {
        ["-d"] = "1",
    };*/

    // why i decided to use private fields for flags instead of map:
    // because in dictionary we can only store string objects and I dont find it convenient in many cases,
    // when flags mean different types of parameters for program executing
    private int _depth = 1;
    public TreeListCommand()
    {
    }

    public TreeListCommand(int depth)
    {
        _depth = depth;
    }

    public bool AreValidArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count >= 1) return false;
        return true;
    }

    public bool IsValidFlag(IList<string> flagArguments)
    {
        if (flagArguments is null) throw new ArgumentNullException(nameof(flagArguments));
        if (flagArguments.Count == 0) return true;
        switch (flagArguments[0])
        {
            case "-d":
                _depth = int.Parse(flagArguments[1], NumberFormatInfo.InvariantInfo);
                return true;
        }

        return true;
    }

    public void Execute(ExecutionContext context)
    {
        if (context?.CurrentPath is null) throw new ArgumentNullException(nameof(context));
        PrintDirectoryTree(context.CurrentPath);
    }

    public void PrintDirectoryTree(string pathToRootDirectory)
    {
        if (!Directory.Exists(pathToRootDirectory)) return;
        var rootDirectory = new DirectoryInfo(pathToRootDirectory);
        PrintCurrentDirectory(@rootDirectory, 0);
    }

    private void PrintCurrentDirectory(DirectoryInfo directory, int currentDepth)
    {
        if (currentDepth > _depth) return;
        string indentation = string.Empty;
        for (int i = 0; i < currentDepth; i++) indentation += '\t';

        Console.WriteLine($"{indentation}-{directory.Name}");
        int nextDepth = currentDepth + 1;
        foreach (DirectoryInfo subDirectory in directory.GetDirectories())
        {
            PrintCurrentDirectory(subDirectory, nextDepth);
        }
    }
}