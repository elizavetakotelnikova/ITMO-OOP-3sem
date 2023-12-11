using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;
namespace Application.Migration;
#pragma warning disable SA1649
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
       'top_up'
    );
    
    create type order_result_state as enum
    (
        'completed',
        'rejected'
    );

    create table users
    (
        user_id bigint primary key generated always as identity,
        user_name text not null ,
        user_role user_role not null,
        user_password text not null
    );
    
    create table accounts_data
    (
        account_id bigint primary key generated always as identity,
        account_pin int 
    );
    
    create table accounts
    (
        user_id bigint not null references users(user_id),
        account_id bigint not null references accounts_data(account_id),
        
        primary key(user_id, account_id)
    );

    create table transactions_info
    (
        transaction_id bigint primary key generated always as identity ,
        transaction_account bigint not null references accounts_data(account_id),
        transaction_type transaction_type not null,
        transaction_state transaction_state not null 
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