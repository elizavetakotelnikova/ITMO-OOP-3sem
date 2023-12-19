using DomainLayer.ValueObjects;

namespace DomainLayer.Models;

public class Transaction
{
    public Transaction(long accountId, TransactionType type, TransactionState state)
    {
        AccountId = accountId;
        Type = type;
        State = state;
    }

    public long AccountId { get; set; }
    public TransactionType Type { get; set; }
    public TransactionState State { get; set; }
}