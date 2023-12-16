using Application.Models;
using DomainLayer.Models;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;
using Ports.Repositories;

namespace Adapters.Persistence;

public class DataBaseAccountRepository : IAccountsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public DataBaseAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Account? FindAccountByAccountId(long accountId)
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

    public User? FindUserByAccountId(long? accountId)
    {
        const string sql = """
                           With tmp(userId)
                           AS (select user_id FROM accounts_data
                           where account_id = :accountId)
                           
                           select user_id, user_role, user_name, user_password
                           from users
                           INNER JOIN tmp AS tmp
                           ON tmp.userId = users.user_id
                           where user_id = userId;
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

        return new User(
            reader.GetInt64(0),
            reader.GetFieldValue<UserRole>(1),
            reader.GetValue(2).ToString(),
            reader.GetValue(3).ToString());
    }

    public void UpdateAmount(Account account, int amount)
    {
        if (account is null) throw new ArgumentException("Operation cannot be done");
        const string sql = """
                           update accounts_data
                           set account_amount = account_amount + :amount
                           where account_id = :accountId;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("accountId", account.Id);
        command.AddParameter("amount", amount);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
    }

    public void Add(Account account, User user)
    {
        if (account is null || user is null) throw new ArgumentException("Operation cannot be done");
        const string sql = """
                           INSERT INTO accounts_data(account_pin, account_amount, user_id) VALUES(@pinCode, @balance, @user_id)
                           RETURNING account_id;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("@pinCode", account.PinCode);
        command.AddParameter("@balance", account.Balance);
        command.AddParameter("@user_id", user.Id);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
        if (reader.Read() is false)
            throw new ArgumentException("Operation cannot be done");
        account.Id = reader.GetInt64(0);
    }
}