using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Display : IDisplay
{
    public Message? Message { get; set; }

    public void DisplayMessage(Message currentMessage)
    {
        if (currentMessage is null) return;
        Message = currentMessage;
        string path = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")), "DisplayConsole");
        var file = new StreamWriter(@path, true);
        if (Message.Heading is not null)
        {
            Console.WriteLine(Message.Heading);
            file.WriteLine(Message.Heading);
        }

        if (Message.MainPart is not null)
        {
            Console.WriteLine(Message.MainPart);
            file.WriteLine(Message.MainPart);
        }

        file.Close();
    }
}