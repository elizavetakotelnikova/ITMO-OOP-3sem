using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class DisplayReceiver : ISend, ISort
{
    public Display.Display? ConcreteAddressee { get; set; }

    // public IList<Message> Messages { get; } = new List<Message>();
    public void SendMessage(Message message)
    {
        if (ConcreteAddressee is null) return;
        var driverDisplay = new DriverDisplay(ConcreteAddressee);

        ConcreteAddressee.Message = message;
        // driverDisplay.DisplayMessage();
    }

    public void SendMessageWithPriority(Message message, int priority)
    {
        if (CheckPriority(message, priority))
        {
            if (ConcreteAddressee is null) return;
            var driverDisplay = new DriverDisplay(ConcreteAddressee);

            ConcreteAddressee.Message = message;
            // driverDisplay.DisplayMessage();
        }
    }

    public bool CheckPriority(Message message, int priority)
    {
        if (message?.ImportanceLevel >= priority) return true;
        return false;
    }
}