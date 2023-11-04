using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface ISendToConcreteAddressee : ISend
{
    public string GetAddresseeName();
}