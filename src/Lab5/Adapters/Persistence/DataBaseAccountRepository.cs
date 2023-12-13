using Application.Models;
using DomainLayer.Models;
using DomainLayer.ValueObjects;
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
                           set account_amount = account_amount + @amount
                           where account_id = :accountId;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("accountId", account.AccountId);
        command.AddParameter("amount", amount);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
    }

    public void Add(Account account, User user)
    {
        if (account is null || user is null) throw new ArgumentException("Operation cannot be done");
        const string sql = """
                           INSERT INTO accounts_data(account_pin, account_amount, user_id) VALUES(@account.AccountPincode, @account.Amount, @user_id)
                           RETURNING account_id;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("@user_id", user.Id);
        command.AddParameter("@account.AccountPincode", account.AccountPinCode);
        command.AddParameter("@account.Amount", account.Amount);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
        if (reader.Read() is false)
            throw new ArgumentException("Operation cannot be done");
        account.AccountId = reader.GetInt64(0);
    }

    public void Add(AvailableAccountInfo account, User user)
    {
        if (account is null || user is null) throw new ArgumentException("Operation cannot be done");
        const string sql = """
                           INSERT INTO accounts_data(account_pin, account_amount, user_id) VALUES(@account.AccountPincode, @account.Amount, @user_id)
                           RETURNING account_id;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("@user_id", user.Id);
        command.AddParameter("@account.AccountPincode", account.AccountPinCode);
        command.AddParameter("@account.Amount", account.Amount);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
        if (reader.Read() is false)
            throw new ArgumentException("Operation cannot be done");
        account.AccountId = reader.GetInt64(0);
    }

    /*public void Add(int pinCode, User user)
    {
        if (user is null) throw new ArgumentException("Operation cannot be done");

        // не факт что так будет работать без переменной аккаунт айди
        const string sql = """
                           INSERT INTO accounts_data(account_pin, account_amount) VALUES(@account.AccountPincode, @account.Amount)
                           RETURNING account_id;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("@account.AccountPincode", pinCode);
        command.AddParameter("@account.Amount", 0);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
        if (reader.Read() is false)
            throw new ArgumentException("Operation cannot be done");

        const string sqlSecond = """
                                 INSERT INTO accounts(user_id, account_id) VALUES(@user.user_id, @AccountId);
                                 """;

        using var commandSecond = new NpgsqlCommand(sqlSecond, connection);

        command.AddParameter("AccountId", reader.GetInt64(0));
        command.AddParameter("user.user_id", user.Id);
        using NpgsqlDataReader secondReader = commandSecond.ExecuteReader();
        commandSecond.Dispose();
        if (secondReader.Read() is false)
            throw new ArgumentException("Operation cannot be done");
    }*/

    public long SelectNextAccountId()
    {
        const string sql = """
                           SELECT LAST_VALUE(account_id) PARTITION BY(account_id)
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
            throw new ArgumentException("Operation cannot be done");

        return reader.GetInt64(0);
    }

    /*public void InsertTransaction(Account account)
    {
        if (account is null) throw new ArgumentException("Operation cannot be done");

        // не факт что так будет работать без переменной аккаунт айди
        const string sql = """
                           INSERT INTO accounts_data(account_id, SecondName) VALUES(@(SELECT LAST_VALUE(account_id) PARTITION BY(account_id)), @account.AccountPincode);
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
    }*/
}