using System;
using System.IO;
using Crayon;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class DriverDisplay : IDisplay
{
    private readonly IDisplay? _display;

    public DriverDisplay(IDisplay display, IOutput color, IOutput secondColor)
    {
        _display = display;
        HeadingColor = color;
        MainPartColor = secondColor;
    }

    public DriverDisplay(IDisplay display, IOutput color, IOutput secondColor, bool flag)
    {
        _display = display;
        HeadingColor = color;
        MainPartColor = secondColor;
        ShouldBeWritten = flag;
    }

    public IOutput HeadingColor { get; set; }
    public IOutput MainPartColor { get; set; }

    public bool ShouldBeWritten { get; set; }

    public void DisplayMessage(Message currentMessage)
    {
        Console.Clear(); // clearing display's console
        if (currentMessage is null) return;
        if (currentMessage.Heading is not null) currentMessage.Heading = HeadingColor.Text(currentMessage.Heading);
        if (currentMessage.MainPart is not null) currentMessage.MainPart = MainPartColor.Text(currentMessage.MainPart);
        string path = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")), "DisplayConsole");
        File.WriteAllText(path, string.Empty);
        _display?.DisplayMessage(currentMessage);
        if (ShouldBeWritten)
        {
            path = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")), "DisplayWrittenText");
            var file = new StreamWriter(@path, true);  // "writting in the file"
            File.WriteAllText(path, string.Empty);
            file.WriteLine(currentMessage.Heading);
            file.WriteLine(currentMessage.MainPart);
            file.WriteLine();
            file.Close();
        }
    }
}