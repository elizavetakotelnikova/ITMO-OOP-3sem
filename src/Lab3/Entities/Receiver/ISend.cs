using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public interface ISend
{
    // public IList<Message> Messages { get; }
    public void SendMessage(Message message);
    public void SendMessageWithPriority(Message message, int priority);
}