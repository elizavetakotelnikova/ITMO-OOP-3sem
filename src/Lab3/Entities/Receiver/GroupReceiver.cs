using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class GroupReceiver : ISend
{
    public IList<ISend> ConcreteAddressee { get; } = new List<ISend>();
    public void SendMessage(Message message)
    {
        if (ConcreteAddressee is null) return;
        foreach (ISend addressee in ConcreteAddressee)
        {
            if (addressee is not GroupReceiver)
            {
                var proxyAddressee = new ProxyAddressee(addressee);
                proxyAddressee.SendMessage(message);
            }
            else
            {
                addressee.SendMessage(message);
            }
        }
    }
}