using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class MessageInformation
{
    public MessageInformation(Message message, string id)
    {
        MessageID = id;
        Message = message;
        IsRead = false;
    }

    public string MessageID { get; }
    public Message? Message { get; set; }
    public bool IsRead { get; set; }
}