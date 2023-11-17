using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class ExecutionContext
{
    public ExecutionContext(string currentPath)
    {
        CurrentPath = currentPath;
    }

    public string CurrentPath { get; set; } = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
}