namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class ExecutionContext
{
    public ExecutionContext(string? currentPath)
    {
        CurrentPath = currentPath;
    }

    public string? CurrentPath { get; set; }
}