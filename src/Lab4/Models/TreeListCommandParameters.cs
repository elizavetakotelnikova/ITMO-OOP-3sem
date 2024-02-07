namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record TreeListCommandParameters
{
    public TreeListCommandParameters(char directorSymbol, char fileSymbol, char indentation)
    {
        DirectorySymbol = directorSymbol;
        FileSymbol = fileSymbol;
        Indentation = indentation;
    }

    public char DirectorySymbol { get; set; }
    public char FileSymbol { get; set; }
    public char Indentation { get; set; }
}