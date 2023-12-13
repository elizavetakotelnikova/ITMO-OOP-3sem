using DomainLayer.Models;
using ExecutionContext = DomainLayer.Models.ExecutionContext;

namespace Ports.Repositories;

public interface ITransactionsRepository
{
    void Add(ExecutionContext context, ICommand command);
    IList<string>? GetInfo(ExecutionContext context);
}