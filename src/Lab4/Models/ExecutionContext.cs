namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class ExecutionContext
{
    public ExecutionContext(string? currentPath)
    {
        CurrentPath = currentPath;
    }

    public string? CurrentPath { get; set; }

    // public string? CurrentPath { get; set; } = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
}