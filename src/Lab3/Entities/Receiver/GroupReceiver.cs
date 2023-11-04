using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class GroupReceiver : ISendToConcreteAddressee
{
    public IList<ISendToConcreteAddressee> ConcreteAddressee { get; } = new List<ISendToConcreteAddressee>();

    public void SendMessage(Message message)
    {
        if (ConcreteAddressee is null) return;
        foreach (ISendToConcreteAddressee addressee in ConcreteAddressee)
        {
            var proxyAddressee = new ProxyAddressee(addressee);
            proxyAddressee.SendMessage(message);
        }
    }

    public string GetAddresseeName()
    {
        return "Group of addressees";
    }
}