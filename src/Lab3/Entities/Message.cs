using Itmo.ObjectOrientedProgramming.Lab3.Entities;
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
    public string? MainPart { get; set; }
    public int ImportanceLevel { get; }

    public void SendToTopic(Topic topic)
    {
        topic?.MessagesList.Add(this);
    }
}