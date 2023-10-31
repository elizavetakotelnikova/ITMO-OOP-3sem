using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message
{
    public Message(string? heading, string mainPart, int importanceLevel)
    {
        Heading = heading;
        MainPart = mainPart;
        ImportanceLevel = importanceLevel;
        IsRead = false;
    }

    public string? Heading { get; }
    public string? MainPart { get; } // или переделать в абзацы
    public int ImportanceLevel { get; }
    public bool IsRead { get; set; }

    public void SendToTopic(Topic topic)
    {
        topic?.MessagesList.Add(this);
    }
}