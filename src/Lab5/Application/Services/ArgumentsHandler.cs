using DomainLayer.Models;

namespace Application.Services;

public class ArgumentsHandler : ResponsibilityChainBase
{
    public override void Handle(Request request)
    {
        if (request is null || request.Command is null) throw new ArgumentNullException(nameof(request));

        var arguments = new List<string>();
        foreach (string part in request.TokenizedLine)
        {
            arguments.Add(part);
        }

        foreach (string item in arguments)
        {
            request.TokenizedLine.Remove(item);
        }

        if (request.Command.ValidateArguments(arguments))
        {
            Next?.Handle(request);
            return;
        }

        throw new ArgumentException("Invalid command"); // можно добавить именно про аргументы
    }
}