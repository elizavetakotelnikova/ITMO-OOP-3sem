using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class DriverDisplay : IShow
{
    private readonly Display? _display;

    public DriverDisplay(Display display)
    {
        _display = display;
    }

    public Colors Color { get; set; }

    public void DisplayMessage()
    {
        _display?.DisplayMessage();
    }

    public void DisplayColorMessage(Colors color)
    {
        _display?.DisplayColorMessage(color);
    }
}