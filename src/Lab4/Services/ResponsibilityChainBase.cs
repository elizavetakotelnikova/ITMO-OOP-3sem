namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public abstract class ResponsibilityChainBase : IChainLink
{
    protected IChainLink? Next { get; set; }
    public void AddNext(IChainLink link)
    {
        if (Next is null)
        {
            Next = link;
        }
        else
        {
            Next.AddNext(link);
        }
    }

    public abstract void Handle(Request request);
}