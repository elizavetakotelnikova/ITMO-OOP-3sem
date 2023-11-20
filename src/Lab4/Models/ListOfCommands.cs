using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record ListOfCommands
{
    private static ListOfCommands? _instance;
    private static TreeListCommandParameters? _treeListCommandParameters;

    public ListOfCommands(TreeListCommandParameters? treeListCommandParameters)
    {
        _treeListCommandParameters = treeListCommandParameters;
    }

    public Dictionary<string, Func<ICommand>> CommandsDictionary { get; } = new Dictionary<string, Func<ICommand>>()
    {
        ["connect"] = () => new ConnectCommand(),
        ["disconnect"] = () => new DisconnectCommand(),
        ["file delete"] = () => new FileDeleteCommand(),
        ["file show"] = () => new FileShowCommand(),
        ["file copy"] = () => new FileCopyCommand(),
        ["tree list"] = () => new TreeListCommand(_treeListCommandParameters),
        ["file move"] = () => new FileMoveCommand(),
        ["tree goto"] = () => new GoToCommand(),
        ["file rename"] = () => new FileRenameCommand(),
    };

    public static ListOfCommands ReturnInstance(TreeListCommandParameters parameters)
    {
        if (_instance is not null)
        {
            return _instance;
        }

        _instance = new ListOfCommands(parameters);
        return _instance;
    }
}