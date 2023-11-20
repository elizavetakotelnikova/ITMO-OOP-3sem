using System;
using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class TreeListCommand : ICommand
{
    // why i decided to use private fields for flags instead of map:
    // because in dictionary we can only store object of one type, I dont find it convenient in many cases,
    // when flags mean different types of parameters for program executing
    private IImplementFileSystem _receiver;
    private int _depth = 1;
    private TreeListCommandParameters _treeParameters = new TreeListCommandParameters((char)220, (char)48, '-');
    public TreeListCommand(IImplementFileSystem? receiver)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public TreeListCommand(IImplementFileSystem? receiver, TreeListCommandParameters? parameters)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        _treeParameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
    }

    public TreeListCommand(IImplementFileSystem? receiver, int depth)
    {
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
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
        _receiver.PrintTreeList(context, _depth, _treeParameters);
    }
}