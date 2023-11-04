using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.MessengerDirectory;

public class Messenger
{
    public IList<Message> MessagesList { get; } = new List<Message>();
    public virtual void DisplayMessage(Message message)
    {
        Console.WriteLine("Messenger:");
        Console.WriteLine(message?.Heading);
        Console.WriteLine(message?.MainPart);
    }

    public virtual void DisplayAllMessages()
    {
        Console.WriteLine("Messenger:");
        foreach (Message mes in MessagesList)
        {
            Console.WriteLine(mes.Heading);
            Console.WriteLine(mes.MainPart);
        }
    }
}