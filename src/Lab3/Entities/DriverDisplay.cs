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

    public IOutput Color { get; set; }

    public void DisplayMessage(Message currentMessage)
    {
        if (currentMessage is null) return;
        if (currentMessage.Heading is not null) currentMessage.Heading = Color.Text(currentMessage.Heading);
        if (currentMessage.MainPart is not null) currentMessage.MainPart = Color.Text(currentMessage.MainPart);
        _display?.DisplayMessage(currentMessage);
    }
}