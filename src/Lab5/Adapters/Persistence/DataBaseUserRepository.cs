using DomainLayer.Models;
using DomainLayer.ValueObjects;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;
using Ports.Repositories;

namespace Adapters.Persistence;

public class DataBaseUserRepository : IUsersRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public DataBaseUserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public User? FindUserByUsername(string username)
    {
        const string sql = """
                           select user_id, user_role, user_name, user_password
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
            reader.GetFieldValue<UserRole>(1),
            reader.GetString(2),
            reader.GetString(3));
    }

    public string? FindPasswordByUsername(string username)
    {
        const string sql = """
                           select user_id, user_name, user_password
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

    public bool ExistsId(long? id)
    {
        if (id is null) return false;
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
        command.AddParameter("id", id);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
        if (reader.Read() is false)
            return false;

        return true;
    }

    public bool ExistsUsername(string username)
    {
        if (username is null) return false;
        const string sql = """
                           select user_id
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
            return false;

        return true;
    }

    public void Add(User user)
    {
        if (user is null) throw new ArgumentException("Operation cannot be done");

        if ((user.Name is not null && ExistsUsername(user.Name)) || (user.Id != 0 && ExistsId(user.Id))) return;
        const string sql = """
                           INSERT INTO users(user_name, user_role, user_password) VALUES(@username, @userRole, @userPassword)
                           RETURNING user_id;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("@username", user.Name);
        command.AddParameter("@userRole", user.Role);
        command.AddParameter("@userPassword", user.Password);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
        if (reader.Read() is false)
            return;
        user.Id = reader.GetInt64(0);
    }

    public void Delete(User user)
    {
        if (user is null || user.Id == 0) throw new ArgumentException("Operation cannot be done");
        const string sql = """
                           DELETE FROM users
                           WHERE user_id = :userId
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userId", user.Id);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Dispose();
    }
}