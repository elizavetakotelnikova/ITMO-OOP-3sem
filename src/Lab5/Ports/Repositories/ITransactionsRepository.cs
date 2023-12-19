using DomainLayer.Models;
using ExecutionContext = DomainLayer.Models.ExecutionContext;

namespace Ports.Repositories;

public interface ITransactionsRepository
{
    void Add(ExecutionContext context, ICommand command);
    void DeleteByAccountId(long? accountId);
    void DeleteByUserId(long? userId);
    IList<string>? GetInfo(ExecutionContext context);
    IList<Transaction>? GetTransactionsByUserId(ExecutionContext context);
}