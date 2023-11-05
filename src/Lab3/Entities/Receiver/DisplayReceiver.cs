using Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDirectory;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class DisplayReceiver : ISendToConcreteAddressee
{
    public DisplayReceiver(IDisplay display)
    {
        ConcreteAddressee = display;
    }

    public IDisplay? ConcreteAddressee { get; set; }

    public void SendMessage(Message message)
    {
        if (ConcreteAddressee is null) return;
        ConcreteAddressee.DisplayMessage(message);
    }

    public string GetAddresseeName()
    {
        return "Display";
    }
}