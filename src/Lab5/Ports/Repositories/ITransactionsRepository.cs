using DomainLayer.Models;
using ExecutionContext = DomainLayer.Models.ExecutionContext;

namespace Ports.Repositories;

public interface ITransactionsRepository
{
    void Add(ExecutionContext context, ICommand command);
    void DeleteByAccountId(long? accountId);
    IList<string>? GetInfo(ExecutionContext context);
}