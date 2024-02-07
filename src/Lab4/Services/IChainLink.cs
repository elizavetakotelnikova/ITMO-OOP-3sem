using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface IChainLink
{
    IChainLink AddNext(IChainLink link);
    void Handle(ParsingRequest request);
}