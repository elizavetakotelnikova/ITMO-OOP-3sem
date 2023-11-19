using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public abstract class ResponsibilityChainBase : IChainLink
{
    protected IChainLink? Next { get; private set; }
    public IChainLink AddNext(IChainLink link)
    {
        if (Next is null)
        {
            Next = link;
        }
        else
        {
            Next.AddNext(link);
        }

        return this;
    }

    public abstract void Handle(ParsingRequest request);
}