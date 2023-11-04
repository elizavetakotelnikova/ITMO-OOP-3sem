using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class User
{
    public User(int id)
    {
        ID = id;
    }

    public int ID { get; }

    public IList<MessageWithInfo> MessageInfo { get; } = new List<MessageWithInfo>();

    public void SetRead(Message message)
    {
        MessageWithInfo? selectedMessage = MessageInfo.FirstOrDefault(element => element.Message == message && !element.IsRead);
        if (selectedMessage is null) throw new InvalidOperationException("Message is already read");
        selectedMessage.IsRead = true;
    }
}