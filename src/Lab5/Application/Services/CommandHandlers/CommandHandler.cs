using DomainLayer.Models;

namespace Application.Services.CommandHandlers;

public class CommandHandler : ResponsibilityChainBase
{
    public override void Handle(Request request)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));
        if (request.TokenizedLine.Count == 0) throw new ArgumentException("Command is not set");

        string commandPart = string.Empty;
        var listToRemove = new List<string>();
        foreach (string part in request.TokenizedLine)
        {
            commandPart += part;
            if (ConfigureCommands.CommandsDictionary.TryGetValue(commandPart, out Func<ICommand>? commandDelegate))
            {
                request.Command = commandDelegate();
                listToRemove.Add(part);
                foreach (string item in listToRemove)
                {
                    request.TokenizedLine.Remove(item);
                }

                Next?.Handle(request);
                return;
            }

            listToRemove.Add(part);
            commandPart += " ";
        }

        throw new ArgumentException("Invalid command");
    }
}