using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class TreeListCommand : ICommand
{
    public TreeListCommand()
    {
    }

    public TreeListCommand(int depth)
    {
        Depth = depth;
    }

    // public IList<List<IComponent>> Directories { get; } = new List<List<IComponent>>();
    public int Depth { get; set; } = 1;

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
                Depth = int.Parse(flagArguments[1], NumberFormatInfo.InvariantInfo);
                return true;
        }

        return false;
    }

    public void Execute(ExecutionContext context)
    {
        if (context?.CurrentPath is null) throw new ArgumentNullException(nameof(context));
        PrintDirectoryTree(context.CurrentPath);
    }

    public void PrintDirectoryTree(string pathToRootDirectory)
    {
        if (!System.IO.Directory.Exists(pathToRootDirectory)) return;
        var rootDirectory = new DirectoryInfo(pathToRootDirectory);
        PrintCurrentDirectory(@rootDirectory, 0);
    }

    private void PrintCurrentDirectory(DirectoryInfo directory, int currentDepth)
    {
        if (currentDepth > Depth) return;
        string indentation = string.Empty;
        for (int i = 0; i < currentDepth; i++) indentation += '\t';

        Console.WriteLine($"{indentation}-{directory.Name}");
        int nextDepth = currentDepth + 1;
        foreach (DirectoryInfo subDirectory in directory.GetDirectories())
        {
            PrintCurrentDirectory(subDirectory, nextDepth);
        }
    }

    /*public static List<IComponent> AddAllInDirectory(string currentPath)
    {
        string[] subDirectories = System.IO.Directory.GetDirectories(currentPath);
        var allComponents = new List<IComponent>();
        foreach (string name in subDirectories)
        {
            var currentDirectory = new Directory(name); // получаем все директории
            allComponents.Add(currentDirectory);
        }

        string[] subFiles = System.IO.Directory.GetFiles(currentPath);

        // var allFiles = new List<Composite.File>();
        foreach (string name in subFiles)
        {
            var currentFile = new Composite.File(name); // получаем все файлы
            allComponents.Add(currentFile);
        }

        return allComponents;
    }*/

    /*public void AddCatalogs(ExecutionContext context)
    {
        if (context?.CurrentPath is null) throw new ArgumentNullException(nameof(context));
        string currentPath = context.CurrentPath;
        List<IComponent> currentInsides = AddAllInDirectory(currentPath);
        for (int i = 0; i < Depth; i++)
        {
        }
    }*/

    /*public void AddCatalogs(ExecutionContext context)
    {
        if (context?.CurrentPath is null) throw new ArgumentNullException(nameof(context));
        string currentPath = context.CurrentPath;
        for (int i = 0; i < Depth; i++)
        {
            string[] subDirectories = System.IO.Directory.GetDirectories(currentPath);
            var allComponents = new List<IComponent>();
            foreach (string name in subDirectories)
            {
                var currentDirectory = new Directory(name); // получаем все директории
                allComponents.Add(currentDirectory);
            }

            string[] subFiles = System.IO.Directory.GetFiles(currentPath);

            // var allFiles = new List<Composite.File>();
            foreach (string name in subFiles)
            {
                var currentFile = new Composite.File(name); // получаем все файлы
                allComponents.Add(currentFile);
            }
        }
    }*/
}