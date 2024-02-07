using DomainLayer.ValueObjects;
using Itmo.Dev.Platform.Postgres.Plugins;
using Npgsql;

namespace Application.Extensions;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        if (builder is null) throw new ArgumentNullException(nameof(builder));
        builder.MapEnum<UserRole>();
        builder.MapEnum<TransactionState>();
        builder.MapEnum<TransactionType>();
    }
}