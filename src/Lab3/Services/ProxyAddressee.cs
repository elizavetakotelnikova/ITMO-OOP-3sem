using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class ProxyAddressee : ISend
{
    public ProxyAddressee(ISendToConcreteAddressee addressee)
    {
        Addressee = addressee;
        CurrentPriority = 0;
        ShouldBeLogged = false;
    }

    public ProxyAddressee(ISendToConcreteAddressee addressee, int currentPriority)
    {
        Addressee = addressee;
        CurrentPriority = currentPriority;
        ShouldBeLogged = true;
    }

    public int CurrentPriority { get; set; }
    public ISendToConcreteAddressee Addressee { get; set; }
    public bool ShouldBeLogged { get; set; }

    public static bool CheckPriority(Message message, int priority)
    {
        if (message?.ImportanceLevel >= priority) return true;
        return false;
    }

    public void SendMessage(Message message)
    {
        if (CheckPriority(message, CurrentPriority) && Addressee is not null)
        {
            Addressee.SendMessage(message);
            if (ShouldBeLogged)
            {
                var file = new StreamWriter("LogsFile", true);
                file.WriteLine("New message for " + Addressee.GetAddresseeName());
                file.Dispose();
            }
        }
    }
}