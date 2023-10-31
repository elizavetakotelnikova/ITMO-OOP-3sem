using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public interface ISort
{
    public bool CheckPriority(Message message, int priority);
}