using Itmo.ObjectOrientedProgramming.Lab3.Entities.MessengerDirectory;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class MessengerReceiver : ISendToConcreteAddressee
{
    public MessengerReceiver(Messenger messenger)
    {
        ConcreteAddressee = messenger;
    }

    public string Name { get; } = "Messenger";
    public Messenger ConcreteAddressee { get; set; }

    public virtual void SendMessage(Message message)
    {
        ConcreteAddressee.MessagesList.Add(message);
        ConcreteAddressee.DisplayMessage(message);
    }

    public string GetAddresseeName()
    {
        return "Messenger";
    }
}