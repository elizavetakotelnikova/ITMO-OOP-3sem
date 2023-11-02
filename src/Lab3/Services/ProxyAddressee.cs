using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class ProxyAddressee : ISend
{
    public ProxyAddressee(ISend addressee)
    {
        Addressee = addressee;
        CurrentPriority = 0;
    }

    public ProxyAddressee(ISend addressee, int currentPriority)
    {
        Addressee = addressee;
        CurrentPriority = currentPriority;
    }

    public int CurrentPriority { get; set; }
    public ISend Addressee { get; set; }

    public static bool CheckPriority(Message message, int priority)
    {
        if (message?.ImportanceLevel >= priority) return true;
        return false;
    }

    public void SendMessageWithPriority(Message message)
    {
        if (CheckPriority(message, CurrentPriority)) Addressee?.SendMessage(message);
    }

    public void SendMessage(Message message)
    {
        Addressee?.SendMessage(message);
    }
}