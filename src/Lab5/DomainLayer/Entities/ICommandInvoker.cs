using DomainLayer.Models;

namespace DomainLayer.Entities;

public interface ICommandInvoker
{
    void Consume(ICommand command);
}