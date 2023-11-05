using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDirectory;

public class Display : IDisplay
{
    public Message? Message { get; set; }

    public void DisplayMessage(Message currentMessage)
    {
        if (currentMessage is null) return;
        Message = currentMessage;
        if (Message.Heading is not null) Console.WriteLine(Message.Heading);
        if (Message.MainPart is not null) Console.WriteLine(Message.MainPart);
    }

    public void DisplayInFile(Message currentMessage)
    {
        string path = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")), "DisplayConsole");
        var file = new StreamWriter(@path, true);
        Message = currentMessage;
        if (Message.Heading is not null) file.WriteLine(Message.Heading);
        if (Message.MainPart is not null) file.WriteLine(Message.MainPart);
        file.Close();
    }
}