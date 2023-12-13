using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;
namespace Application.Migration;
[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create type user_role as enum
    (
        'admin',
        'user'
    );

    create type transaction_state as enum
    (
        'commit',
        'rollback'
    );
    
    create type transaction_type as enum
    (
       'view',
       'withdraw',
       'topUp',
       'login',
       'creation'
    );

    create table users
    (
        user_id bigint primary key generated always as identity,
        user_name text,
        user_role user_role not null,
        user_password text
    );
    
    create table accounts_data
    (
        account_id bigint primary key generated always as identity,
        account_pin int,
        account_amount int,
        user_id bigint not null references users(user_id)
    );

    create table transactions_info
    (
        transaction_id bigint primary key generated always as identity ,
        transaction_account bigint references accounts_data(account_id),
        transaction_type transaction_type not null,
        transaction_state transaction_state not null,
        transaction_userId bigint not null references users(user_id)
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table users;
    drop table accounts;
    drop table accounts_data;
    drop table transactions_info;
    """;
}