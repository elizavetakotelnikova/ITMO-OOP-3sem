// using Application.Models;

using Application.Models;
using Application.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Adapters.Persistence;

public class DataBaseUserRepository : IUsersRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public DataBaseUserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    /*public User? FindUserByUsername(string username)
    {
        const string sql = """
                           select user_id, user_name, user_role
                           from users
                           where user_name = :username;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
        if (reader.Read() is false)
            return null;

        return new User(
            reader.GetInt64(0),
            reader.GetString(1),
            reader.GetFieldValue<UserRole>(2));
    }*/

    public string? FindPasswordByUsername(string username)
    {
        const string sql = """
                           select user_id, user_name, user_password,
                           from users
                           where user_name = :username;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
        if (reader.Read() is false)
            return null;

        return reader.GetString(2);
    }

    public bool ExistsId(long id)
    {
        const string sql = """
                           select user_id
                           from users
                           where user_id = :id;
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
            return false;

        return true;
    }

    public void Add(User user)
    {
        if (user is null) throw new ArgumentException("Operation cannot be done");

        // не факт что так будет работать без переменной аккаунт айди
        const string sql = """
                           INSERT INTO users(users_id, user_name, user_role) VALUES(@user.UserId, @NULL, @user.Role);
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
    }
}