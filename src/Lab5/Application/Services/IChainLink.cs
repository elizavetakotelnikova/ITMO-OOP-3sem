using DomainLayer.Models;

namespace Application.Services;

public interface IChainLink
{
    IChainLink AddNext(IChainLink link);
    void Handle(Request request);
}