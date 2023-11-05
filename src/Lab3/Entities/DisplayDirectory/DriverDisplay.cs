using System;
using System.Drawing;
using System.IO;
using Crayon;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDirectory;

public class DriverDisplay : IDisplay
{
    private readonly IDisplay? _display;

    public DriverDisplay(IDisplay display, Color color, Color secondColor)
    {
        _display = display;
        HeadingColor = color;
        MainPartColor = secondColor;
    }

    public DriverDisplay(IDisplay display, Color color, Color secondColor, bool flag)
    {
        _display = display;
        HeadingColor = color;
        MainPartColor = secondColor;
        ShouldBeWritten = flag;
    }

    public Color HeadingColor { get; set; }
    public Color MainPartColor { get; set; }

    public bool ShouldBeWritten { get; set; }

    public void DisplayMessage(Message currentMessage)
    {
        if (currentMessage is null) return;
        ClearDisplay();
        _display?.DisplayInFile(currentMessage); // "display should implement output as console output and writting in file"
        if (ShouldBeWritten) DisplayInFile(currentMessage); // writting message text in file, "driver display should be able to write text in file"
        if (currentMessage.Heading is not null)
            currentMessage.Heading = Output.Rgb(HeadingColor.R, HeadingColor.G, HeadingColor.B).Text(currentMessage.Heading);
        if (currentMessage.MainPart is not null)
            currentMessage.MainPart = Output.Rgb(MainPartColor.R, MainPartColor.G, MainPartColor.B).Text(currentMessage.MainPart);
        _display?.DisplayMessage(currentMessage);
    }

    public void DisplayInFile(Message currentMessage)
    {
        if (currentMessage is null) return;
        string path = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")), "DisplayDriverWrittenText");
        File.WriteAllText(path, string.Empty);
        var file = new StreamWriter(@path, true); // "writting in the file"
        file.WriteLine(currentMessage.Heading);
        file.WriteLine(currentMessage.MainPart);
        file.WriteLine();
        file.Close();
    }

    private static void ClearDisplay()
    {
        Console.Clear(); // clearing display's console
        string path = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")), "DisplayConsole");
        File.WriteAllText(path, string.Empty); // clearing display's file
    }
}