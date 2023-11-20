using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class Filesystem : IImplementFileSystem
{
    public void Connect(ExecutionContext context, Mode? mode, string address)
    {
        if (address is null || mode is null || context is null) throw new ArgumentNullException(nameof(context));
        var checker = new WindowsPathChecker();
        if (checker.IsValidAbsolutePath(address)) context.CurrentPath = address;
        else context.CurrentPath += address;
    }

    public void Disconnect(ExecutionContext context)
    {
        if (context?.CurrentPath is null) throw new ArgumentNullException(nameof(context));
        context.CurrentPath = null; // next command should be connect, or an exception will be thrown
    }

    public void CopyFile(ExecutionContext context, string sourcePath, string destinationPath)
    {
        if (context?.CurrentPath is null || sourcePath is null || destinationPath is null) throw new ArgumentException("Path is not set");
        var checker = new WindowsPathChecker();

        if (!checker.IsValidAbsolutePath(sourcePath)) sourcePath = context.CurrentPath + sourcePath;
        if (!checker.IsValidAbsolutePath(destinationPath)) destinationPath = context.CurrentPath + destinationPath;
        destinationPath += "\\" + System.IO.Path.GetFileName(sourcePath);
        if (!System.IO.File.Exists(@sourcePath)) throw new ArgumentException("Wrong source path");
        System.IO.File.Copy(@sourcePath, @destinationPath);
    }

    public void DeleteFile(ExecutionContext context, string filePath)
    {
        if (context?.CurrentPath is null) throw new ArgumentNullException(nameof(context));
        if (filePath is null) throw new ArgumentException("_filePath is not set");
        var checker = new WindowsPathChecker();
        if (!checker.IsValidAbsolutePath(filePath)) filePath = context.CurrentPath + filePath;
        if (!System.IO.File.Exists(@filePath)) throw new ArgumentException("Wrong file path");
        System.IO.File.Delete(@filePath);
    }

    public void MoveFile(ExecutionContext context, string sourcePath, string destinationPath)
    {
        if (context?.CurrentPath is null) throw new ArgumentNullException(nameof(context));
        if (sourcePath is null || destinationPath is null) throw new ArgumentException("Path is not set");
        var checker = new WindowsPathChecker();

        if (!checker.IsValidAbsolutePath(sourcePath)) sourcePath = context.CurrentPath + sourcePath;
        if (!checker.IsValidAbsolutePath(destinationPath)) destinationPath = context.CurrentPath + destinationPath;
        destinationPath += "\\" + System.IO.Path.GetFileName(sourcePath);

        if (!System.IO.File.Exists(@sourcePath)) throw new ArgumentException("Wrong source path");
        System.IO.File.Move(@sourcePath, @destinationPath);
    }

    public void RenameFile(ExecutionContext context, string filePath, string newName)
    {
        if (context?.CurrentPath is null) throw new ArgumentNullException(nameof(context));
        if (filePath is null || newName is null) throw new ArgumentException("Parameters are not set");
        var checker = new WindowsPathChecker();
        if (!checker.IsValidAbsolutePath(filePath)) filePath = context.CurrentPath + filePath;
        if (!System.IO.File.Exists(@filePath)) throw new ArgumentException("Wrong source path");
        System.IO.File.Move(@filePath, System.IO.Path.GetDirectoryName(@filePath) + '\\' + newName);
    }

    public void ShowFile(ExecutionContext context, string path, ShowMode? mode)
    {
        if (context?.CurrentPath is null || path is null) throw new ArgumentNullException(nameof(context));
        var checker = new WindowsPathChecker();
        if (!checker.IsValidAbsolutePath(path)) path = context.CurrentPath + path;
        switch (mode)
        {
            case ShowMode.Console:
                var file = new StreamReader(path);
                while (!file.EndOfStream)
                {
                    Console.WriteLine(file.ReadLine());
                }

                file.Close();
                break;
        }
    }

    public void GoToCommand(ExecutionContext context, string path)
    {
        if (context?.CurrentPath is null) throw new ArgumentNullException(nameof(context));
        if (path is null) throw new ArgumentNullException(nameof(path));
        var checker = new WindowsPathChecker();
        if (checker.IsValidAbsolutePath(path)) context.CurrentPath = path;
        else context.CurrentPath += path;
    }

    public void PrintTreeList(ExecutionContext context, int depth, TreeListCommandParameters parameters)
    {
        if (context?.CurrentPath is null) throw new ArgumentNullException(nameof(context));
        PrintDirectoryTree(context.CurrentPath, depth, parameters);
    }

    public void PrintDirectoryTree(string pathToRootDirectory, int depth, TreeListCommandParameters parameters)
    {
        if (!Directory.Exists(pathToRootDirectory)) return;
        var rootDirectory = new DirectoryInfo(pathToRootDirectory);
        PrintCurrentDirectory(@rootDirectory, 0, depth, parameters);
    }

    public void PrintCurrentDirectory(DirectoryInfo directory, int currentDepth, int depth, TreeListCommandParameters parameters)
    {
        if (currentDepth > depth) return;
        if (directory is null || parameters is null) throw new ArgumentNullException(nameof(directory));
        string indentation = string.Empty;
        for (int i = 0; i < currentDepth; i++) indentation += '\t';

        Console.WriteLine($"{indentation}{parameters.Indentation}-{parameters.DirectorySymbol} {directory.Name}");
        int nextDepth = currentDepth + 1;
        foreach (DirectoryInfo subDirectory in directory.GetDirectories())
        {
            PrintCurrentDirectory(subDirectory, nextDepth, depth, parameters);
        }

        foreach (FileInfo fileInfo in directory.GetFiles())
        {
            Console.WriteLine($"{indentation}{parameters.Indentation}-{parameters.FileSymbol} {fileInfo.Name}");
        }
    }
}