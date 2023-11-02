using Itmo.ObjectOrientedProgramming.Lab3.Messages;
namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface IDisplay
{
    public void DisplayMessage(Message currentMessage);
}