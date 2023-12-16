using Application.Commands;
using DomainLayer.Models;
using DomainLayer.ValueObjects;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;
using Ports.Repositories;
using ExecutionContext = DomainLayer.Models.ExecutionContext;

namespace Adapters.Persistence;

public class DataBaseTransactionsRepository : ITransactionsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public DataBaseTransactionsRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public void Add(ExecutionContext context, ICommand command)
    {
        if (context is null || command is null) throw new ArgumentException("Operation cannot be done");
        TransactionType transactionType = TransactionType.View;
        switch (command)
        {
            case LogInCommand:
                transactionType = TransactionType.LogIn;
                break;
            case CreateAccountCommand:
                transactionType = TransactionType.CreateAccount;
                break;
            case CreateUserCommand:
                transactionType = TransactionType.CreateUser;
                break;
            case TopUpCommand:
                transactionType = TransactionType.TopUp;
                break;
            case WithdrawCommand:
                transactionType = TransactionType.Withdraw;
                break;
            case DisconnectCommand:
                return;
            case ShowBalanceCommand:
                transactionType = TransactionType.ShowBalance;
                break;
        }

        const string sql = """
                           INSERT INTO transactions_info(transaction_account, transaction_type, transaction_state, transaction_userId) VALUES(@accountId, @transactionType, @transactionState, @userId);
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var commandSql = new NpgsqlCommand(sql, connection);
        commandSql.AddParameter("@accountId", context.AtmUser?.Account?.Id);
        commandSql.AddParameter("@transactionType", transactionType);
        commandSql.AddParameter("@transactionState", TransactionState.Commit);
        commandSql.AddParameter("@userId", context.AtmUser?.User?.Id);
        using NpgsqlDataReader reader = commandSql.ExecuteReader();
        commandSql.Dispose();
    }

    public IList<string>? GetInfo(ExecutionContext context)
    {
        if (context?.AtmUser?.Account is null) throw new ArgumentException("Operation cannot be done");
        const string sql = """
                           select transaction_account, transaction_type, transaction_state
                           from transactions_info
                           where transaction_account = :id;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", context.AtmUser.Account.Id);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
        if (reader.Read() is false)
            return null;

        IList<string> result = new List<string>();
        while (reader.HasRows)
        {
            result.Add($"Account {reader.GetInt64(0)}, type {reader.GetString(1)}, state {reader.GetString(2)}");
            if (reader.Read() is false) break;
        }

        return result;
    }

    public void DeleteByAccountId(long? accountId)
    {
        if (accountId == 0) throw new ArgumentException("Operation cannot be done");
        const string sql = """
                           DELETE FROM transactions_info
                           WHERE transaction_account = :accountId
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
    }
}