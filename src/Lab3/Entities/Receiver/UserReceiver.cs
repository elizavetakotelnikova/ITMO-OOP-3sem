using System;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class UserReceiver : ISend, ISort
{
    public UserReceiver(User.User user)
    {
        ConcreteAddresse = user;
    }

    public User.User? ConcreteAddresse { get; set; }
    public void SendMessage(Message message)
    {
        if (ConcreteAddresse is null || message is null) return;
        if (ConcreteAddresse.ImportanceLevel >= message.ImportanceLevel)
            ConcreteAddresse.MessageInfo.Add(new MessageInformation(message, DateTime.Today.Second.ToString(new DateTimeFormatInfo()) + ConcreteAddresse.ID.ToString(new NumberFormatInfo())));
    }

    public void SendMessageWithPriority(Message message, int priority)
    {
        if (CheckPriority(message, priority))
        {
            ConcreteAddresse?.MessageInfo.Add(new MessageInformation(message, DateTime.Today.Second.ToString(new DateTimeFormatInfo()) + ConcreteAddresse.ID.ToString(new NumberFormatInfo())));
        }
    }

    public bool CheckPriority(Message message, int priority)
    {
        if (message?.ImportanceLevel >= priority) return true;
        return false;
    }
}