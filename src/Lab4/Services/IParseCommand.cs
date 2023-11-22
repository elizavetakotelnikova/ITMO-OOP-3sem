using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface IParseCommand
{
    public string[]? GetLine();
    public ICommand Parse();
}