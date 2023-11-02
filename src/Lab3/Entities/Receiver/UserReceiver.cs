using System;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class UserReceiver : ISend
{
    public UserReceiver(User user)
    {
        ConcreteAddressee = user;
    }

    public User ConcreteAddressee { get; set; }
    public void SendMessage(Message message)
    {
        if (ConcreteAddressee is null || message is null) return;
        ConcreteAddressee.MessageInfo.Add(
            new MessageWithInfo(
                message,
                DateTime.Today.Second.ToString(new DateTimeFormatInfo()) + ConcreteAddressee.ID.ToString(new NumberFormatInfo())));
    }
}