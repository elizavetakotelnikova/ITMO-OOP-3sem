using System;
using Crayon;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class Display : IShow
{
    public Display(Message message)
    {
        Message = message;
    }

    public Message? Message { get; set; }
    public Colors MessageColor { get; set; }

    public void DisplayMessage()
    {
        Console.Clear();
        if (Message is null) return;
        if (Message.Heading is not null) Console.WriteLine(Message.Heading);
        if (Message.MainPart is not null) Console.WriteLine(Message.MainPart);
    }

    public void DisplayColorMessage(Colors color)
    {
        Console.Clear();
        if (Message is null) return;
        switch (color)
        {
            case Colors.Yellow:
                if (Message.Heading is not null) Console.WriteLine(Output.Yellow(Message.Heading));
                if (Message.MainPart is not null) Console.WriteLine(Output.Yellow(Message.MainPart));
                break;
            case Colors.White:
                if (Message.Heading is not null) Console.WriteLine(Output.White(Message.Heading));
                if (Message.MainPart is not null) Console.WriteLine(Output.White(Message.MainPart));
                break;
            case Colors.Red:
                if (Message.Heading is not null) Console.WriteLine(Output.Red(Message.Heading));
                if (Message.MainPart is not null) Console.WriteLine(Output.Red(Message.MainPart));
                break;
            case Colors.Blue:
                if (Message.Heading is not null) Console.WriteLine(Output.Blue(Message.Heading));
                if (Message.MainPart is not null) Console.WriteLine(Output.Blue(Message.MainPart));
                break;
            case Colors.Black:
                if (Message.Heading is not null) Console.WriteLine(Output.Black(Message.Heading));
                if (Message.MainPart is not null) Console.WriteLine(Output.Black(Message.MainPart));
                break;
            case Colors.Green:
                if (Message.Heading is not null) Console.WriteLine(Output.Green(Message.Heading));
                if (Message.MainPart is not null) Console.WriteLine(Output.Green(Message.MainPart));
                break;
        }

        if (Message.Heading is not null) Console.WriteLine(Message.Heading);
        Console.WriteLine(Message.MainPart);
    }
}