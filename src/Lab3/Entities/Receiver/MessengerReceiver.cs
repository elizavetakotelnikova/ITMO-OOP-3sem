using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class MessengerReceiver : ISend, ISort
{
    public Messenger.Messenger? ConcreteAddresse { get; set; }

    public void SendMessage(Message message)
    {
        ConcreteAddresse?.MessagesList.Add(message);
    }

    public void SendMessageWithPriority(Message message, int priority)
    {
        if (CheckPriority(message, priority))
        {
            ConcreteAddresse?.MessagesList.Add(message);
        }
    }

    public bool CheckPriority(Message message, int priority)
    {
        if (message?.ImportanceLevel >= priority) return true;
        return false;
    }
}