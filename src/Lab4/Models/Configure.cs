using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record Configure
{
    private static Configure? _instance;
    private static TreeListCommandParameters? _treeListCommandParameters;
    private static IImplementFileSystem? _fileSystem;

    public Configure(TreeListCommandParameters? treeListCommandParameters, IImplementFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        _treeListCommandParameters = treeListCommandParameters;
    }

    public Dictionary<string, Func<ICommand>> CommandsDictionary { get; } = new Dictionary<string, Func<ICommand>>()
    {
        ["connect"] = () => new ConnectCommand(_fileSystem),
        ["disconnect"] = () => new DisconnectCommand(_fileSystem),
        ["file delete"] = () => new FileDeleteCommand(_fileSystem),
        ["file show"] = () => new FileShowCommand(_fileSystem),
        ["file copy"] = () => new FileCopyCommand(_fileSystem),
        ["tree list"] = () => new TreeListCommand(_fileSystem, _treeListCommandParameters),
        ["file move"] = () => new FileMoveCommand(_fileSystem),
        ["tree goto"] = () => new GoToCommand(_fileSystem),
        ["file rename"] = () => new FileRenameCommand(_fileSystem),
    };
    public static void ChangeFilesystem(IImplementFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public static Configure ReturnInstance(TreeListCommandParameters parameters, IImplementFileSystem fileSystem)
    {
        if (_instance is not null)
        {
            return _instance;
        }

        _instance = new Configure(parameters, fileSystem);
        return _instance;
    }
}