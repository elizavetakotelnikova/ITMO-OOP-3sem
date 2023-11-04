using System;
using System.IO;
using Crayon;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class DriverDisplay : IDisplay
{
    private readonly IDisplay? _display;

    public DriverDisplay(IDisplay display, IOutput color)
    {
        _display = display;
        Color = color;
    }

    public DriverDisplay(IDisplay display, IOutput color, bool flag)
    {
        _display = display;
        Color = color;
        ShouldBeWritten = flag;
    }

    public IOutput Color { get; set; }

    public bool ShouldBeWritten { get; set; }

    public void DisplayMessage(Message currentMessage)
    {
        Console.Clear(); // clearing display's console
        if (currentMessage is null) return;
        if (currentMessage.Heading is not null) currentMessage.Heading = Color.Text(currentMessage.Heading);
        if (currentMessage.MainPart is not null) currentMessage.MainPart = Color.Text(currentMessage.MainPart);
        _display?.DisplayMessage(currentMessage);
        if (ShouldBeWritten)
        {
            var file = new StreamWriter("DisplayWrittenText", true);  // "writting in the file"
            file.WriteLine(currentMessage.Heading);
            file.WriteLine(currentMessage.MainPart);
            file.WriteLine();
            file.Dispose();
        }

        var fs = new FileStream("DisplayConsole", FileMode.Open); // clearing the display's "console"-file
        fs.SetLength(0);
        fs.Dispose();
    }
}