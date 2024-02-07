namespace DomainLayer.Models;

public class Request
{
    public Request(ICommand? command, IList<string> tokenizedLine)
    {
        Command = command;
        TokenizedLine = tokenizedLine;
    }

    public IList<string> TokenizedLine { get; }
    public ICommand? Command { get; set; }
}