using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class ConsoleHandler : ResponsibilityChainBase
{
    public override void Handle(Request request)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));
        Console.WriteLine(request.Value);
        Next?.Handle(request);
    }
}