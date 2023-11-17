namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface IChainLink
{
    void AddNext(IChainLink link);
    void Handle(Request request);
}