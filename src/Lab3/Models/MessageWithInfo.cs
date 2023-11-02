using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class MessageWithInfo
{
    public MessageWithInfo(Message message, string tag)
    {
        MessageTag = tag;
        Message = message;
        IsRead = false;
    }

    public string MessageTag { get; }
    public Message? Message { get; set; }
    public bool IsRead { get; set; }
}