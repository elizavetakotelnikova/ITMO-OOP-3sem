using Ports.Output;

namespace Adapters.UI;

public class ConsoleDisplayer : IDisplayMessage
{
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}