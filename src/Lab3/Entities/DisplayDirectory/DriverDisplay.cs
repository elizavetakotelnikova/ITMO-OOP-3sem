using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDirectory;

public class DriverDisplay : IDisplay
{
    private readonly IDisplay? _display;

    public DriverDisplay(IDisplay display, ColorModifier color, ColorModifier secondColor)
    {
        _display = display;
        HeadingColor = color;
        MainPartColor = secondColor;
    }

    public DriverDisplay(IDisplay display, ColorModifier color, ColorModifier secondColor, bool flag)
    {
        _display = display;
        HeadingColor = color;
        MainPartColor = secondColor;
        ShouldBeWritten = flag;
    }

    public ColorModifier HeadingColor { get; set; }
    public ColorModifier MainPartColor { get; set; }

    public bool ShouldBeWritten { get; set; }

    public void DisplayMessage(Message currentMessage)
    {
        if (currentMessage is null) return;
        ClearDisplay();
        _display?.DisplayInFile(currentMessage); // "display should implement output as console output and writting in file"
        if (ShouldBeWritten) DisplayInFile(currentMessage); // writting message text in file, "driver display should be able to write text in file"
        if (currentMessage.Heading is not null) currentMessage.Heading = HeadingColor.Modify(currentMessage.Heading);
        if (currentMessage.MainPart is not null) currentMessage.MainPart = MainPartColor.Modify(currentMessage.MainPart);
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