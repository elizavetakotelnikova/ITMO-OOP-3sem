using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class DisplayReceiver : ISend
{
    public IDisplay? ConcreteAddressee { get; set; }

    public void SendMessage(Message message)
    {
        if (ConcreteAddressee is null) return;
        ConcreteAddressee.DisplayMessage(message);
    }
}