using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class MessengerReceiver : ISend
{
    public MessengerReceiver(Messenger messenger)
    {
        ConcreteAddressee = messenger;
    }

    public Messenger ConcreteAddressee { get; set; }

    public void SendMessage(Message message)
    {
        ConcreteAddressee?.MessagesList.Add(message);
    }
}