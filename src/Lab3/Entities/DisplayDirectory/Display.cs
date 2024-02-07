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
        var fileStream = new FileStream(@path, FileMode.OpenOrCreate);
        var streamWriter = new StreamWriter(fileStream);
        Message = currentMessage;
        if (Message.Heading is not null) streamWriter.WriteLine(Message.Heading);
        if (Message.MainPart is not null) streamWriter.WriteLine(Message.MainPart);
        streamWriter.Close();
        fileStream.Close();
    }
}