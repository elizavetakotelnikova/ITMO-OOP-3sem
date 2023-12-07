using Application.Repositories;
using DomainLayer.ValueObjects;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Adapters.Persistence;

public class DataBaseAccountRepository : IAccountsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public DataBaseAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Account? FindAccountByNumber(long accountId)
    {
        const string sql = """
                           select account_id, account_pin, account_amount
                           from accounts_data
                           where account_id = :accountId;
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
        if (reader.Read() is false)
            return null;

        return new Account(
            reader.GetInt64(0),
            reader.GetInt32(1),
            reader.GetInt32(2));
    }

    public void UpdateAmount(Account account, int amount)
    {
        if (account is null) throw new ArgumentException("Operation cannot be done");

        // не факт что так будет работать без переменной аккаунт айди
        const string sql = """
                           update accounts_data
                           set account_amount += amount
                           where account_id = :account.AccountId;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);

        // command.AddParameter("accountId", currentId);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
        if (reader.Read() is false)
            throw new ArgumentException("Operation cannot be done");
    }
}