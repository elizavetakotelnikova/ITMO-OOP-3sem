using System.Globalization;
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
        string transactionTypeString = "view";
        switch (command)
        {
            case LogInCommand:
                transactionType = TransactionType.Login;
                transactionTypeString = "login";
                break;
            case CreateAccountCommand:
                transactionType = TransactionType.Creation;
                transactionTypeString = "creation";
                break;
            case TopUpCommand:
                transactionType = TransactionType.TopUp;
                transactionTypeString = "topUp";
                break;
            case WithdrawCommand:
                transactionType = TransactionType.Withdraw;
                transactionTypeString = "withdraw";
                break;
            case DisconnectCommand:
                return;
        }

        string type = transactionType.ToString().ToLower(new CultureInfo("en-US", false));
        const string sql = """
                           INSERT INTO transactions_info(transaction_account, transaction_type, transaction_state, transaction_userId) VALUES(@accountId, CAST(@transactionType as transaction_type), CAST(@transactionState as "transaction_state"), @userId);
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var commandSql = new NpgsqlCommand(sql, connection);
        commandSql.AddParameter("@accountId", context.AtmUser?.Account?.Id);
        commandSql.AddParameter("@transactionType", transactionTypeString);
        commandSql.AddParameter("@transactionState", "commit");
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
        while (reader.Read())
        {
            result.Add($"Account {reader.GetInt64(0)}, type {reader.GetString(1)}, state {reader.GetString(2)}");
        }

        return result;
    }
}