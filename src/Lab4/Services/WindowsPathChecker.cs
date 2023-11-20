using System.Text.RegularExpressions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class WindowsPathChecker : ICheckPath
{
    public bool IsValidAbsolutePath(string? path)
    {
        var absolutePath = new Regex("[A-Z]:\\\\");
        if (path is not null && absolutePath.IsMatch(path)) return true;
        return false;
    }
}