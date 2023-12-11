using Application.Commands;
using Application.Models;
using Itmo.Dev.Platform.Postgres.Connection;
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
        string? type = null;
        switch (command)
        {
            case LogInCommand:
                type = "login";
                break;
            case CreateAccountCommand:
                type = "creation";
                break;
            case TopUpCommand:
                type = "top up";
                break;
            case WithdrawCommand:
                type = "withdraw";
                break;
        }

        if (type is null) return;
        const string sql = """
                           INSERT INTO transactions_info(transaction_account, transaction_type) VALUES(@context.AtmUser.AccountId, @type, "commit");
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var commandSql = new NpgsqlCommand(sql, connection);

        // command.AddParameter("TransactionsId", currentId);
        using NpgsqlDataReader reader = commandSql.ExecuteReader();
        commandSql.Dispose();
        if (reader.Read() is false)
            throw new ArgumentException("Operation cannot be done");
    }

    public IList<string>? GetInfo(ExecutionContext context)
    {
        if (context is null || context.AtmUser?.Account is null) throw new ArgumentException("Operation cannot be done");

        const string sql = """
                           select transaction_account, transaction_type, transaction_state
                           from transactions_info
                           where account_id = :context.AtmUser.accountId;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
        if (reader.Read() is false)
            return null;

        IList<string> result = new List<string>();
        while (reader.Read())
        {
            result.Add($"Account {reader.GetInt64(0)}, type {reader.GetString(1)}, state {reader.GetString(2)}");
        }

        return result;
    }
}