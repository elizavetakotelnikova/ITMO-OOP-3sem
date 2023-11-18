using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record ListOfCommands
{
    public Dictionary<string, Func<ICommand>> CommandsDictionary { get; } = new Dictionary<string, Func<ICommand>>()
    {
        ["connect"] = () => new ConnectCommand(),
        ["disconnect"] = () => new DisconnectCommand(),
        ["file delete"] = () => new FileDeleteCommand(),
        ["file show"] = () => new FileShowCommand(),
        ["file copy"] = () => new FileCopyCommand(),
        ["tree list"] = () => new TreeListCommand(),
        ["file move"] = () => new FileMoveCommand(),
        ["tree goto"] = () => new GoToCommand(),
        ["file rename"] = () => new FileRenameCommand(),
    };
}