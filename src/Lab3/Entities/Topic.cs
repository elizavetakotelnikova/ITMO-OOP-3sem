using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    public Topic(string name, ISend receiver)
    {
        Name = name;
        Receiver = receiver;
    }

    public IList<Message> MessagesList { get; } = new List<Message>();
    public string? Name { get; }
    public ISend Receiver { get; set; }

    public void GetMessage(Message message)
    {
        MessagesList.Add(message);
    }

    public void SendMessage()
    {
        foreach (Message currentMessage in MessagesList)
        {
            Receiver.SendMessage(currentMessage);
        }
    }

    public void SendLastMessage()
    {
        Receiver.SendMessage(MessagesList.Last());
    }
}