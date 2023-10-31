using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class MessageBuilder
{
    private string? _heading;
    private string? _mainPart;
    private int _importanceLevel;

    public MessageBuilder WithHeading(string heading)
    {
        _heading = heading;
        return this;
    }

    public MessageBuilder WithMainPart(string? mainPart)
    {
        if (mainPart is null) throw new InvalidDataException("Main part of the message cannot be null");

        _mainPart = mainPart;
        return this;
    }

    public MessageBuilder WithImportanceLevel(int importanceLevel)
    {
        _importanceLevel = importanceLevel;
        return this;
    }

    public Message Build()
    {
        if (_mainPart is null) throw new InvalidDataException("Main part of the message cannot be null");
        return new Message(_heading, _mainPart, _importanceLevel);
    }
}