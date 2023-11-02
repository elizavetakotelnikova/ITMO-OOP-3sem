using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Messenger
{
    public IList<Message> MessagesList { get; } = new List<Message>();

    public void DisplayMessage()
    {
        Console.WriteLine("Messenger:");
        foreach (Message mes in MessagesList)
        {
            Console.WriteLine(mes);
        }
    }
}