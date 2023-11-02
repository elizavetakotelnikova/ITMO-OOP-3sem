using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message
{
    public Message(string? heading, string mainPart, int importanceLevel)
    {
        Heading = heading;
        MainPart = mainPart;
        ImportanceLevel = importanceLevel;
    }

    public string? Heading { get; set; }
    public string? MainPart { get; set; } // или переделать в абзацы
    public int ImportanceLevel { get; }

    public void SendToTopic(Topic<MessengerReceiver> topic)
    {
        topic?.MessagesList.Add(this);
    }
}