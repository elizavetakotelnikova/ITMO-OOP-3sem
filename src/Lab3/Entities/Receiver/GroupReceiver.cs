using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class GroupReceiver : ISend
{
    // public IList<Message> Messages { get; } = new List<Message>();
    public IList<ISend> Addressees { get; } = new List<ISend>();
    public void SendMessage(Message message)
    {
        if (Addressees is null) return;
        foreach (ISend addressee in Addressees)
        {
            addressee.SendMessage(message);
        }
    }

    public void SendMessageWithPriority(Message message, int priority)
    {
        if (Addressees is null) return;
        foreach (ISend addressee in Addressees)
        {
            addressee.SendMessageWithPriority(message, priority);
        }
    }
}