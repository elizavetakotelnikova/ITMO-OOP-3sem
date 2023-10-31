using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.User;

public class User
{
    public int ID { get; }
    public IList<(Message Messages, bool Status)> Messages { get; set;  } = new List<(Message Messages, bool Status)>();

    public IList<MessageInformation> MessageInfo { get; } = new List<MessageInformation>();

    public int ImportanceLevel { get; set; }

    public void SetRead(//так в итоге что ты сюда будешь подавать?)
    {
        // отметить сообщение
    }
}