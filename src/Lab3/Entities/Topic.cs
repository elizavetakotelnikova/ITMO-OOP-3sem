using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic<TReceiver>
    where TReceiver : class
{
    public Topic(string name, ISend receiver)
    {
        Name = name;
        Receiver = receiver;
    }

    public IList<Message> MessagesList { get; } = new List<Message>();
    public string? Name { get; }
    public ISend Receiver { get; set; }

    public void SendMessage()
    {
        foreach (Message currentMessage in MessagesList)
        {
            Receiver.SendMessage(currentMessage);
        }
    }
}