using Itmo.ObjectOrientedProgramming.Lab3.Messages;
namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDirectory;

public interface IDisplay
{
    public void DisplayMessage(Message currentMessage);
    public void DisplayInFile(Message currentMessage);
}