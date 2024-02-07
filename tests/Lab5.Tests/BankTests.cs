using System;
using System.Collections.Generic;
using Adapters.Persistence;
using Application.Commands;
using Application.Services.ATMCommandServices;
using DomainLayer.Models;
using DomainLayer.ValueObjects;
using NSubstitute;
using Ports.Input;
using Ports.Output;
using Ports.Repositories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankTests
{
    [Fact]
    public void NotEnoughMoneyToWithdrawWithoutLoggingShouldReturnError()
    {
        IList<Account> accounts = new List<Account>
        {
            new Account(154, 3333, 21, 2),
            new Account(23, 3331, 0, 2),
        };
        IList<User> users = new List<User>
        {
            new User(1, UserRole.Admin, "admin", "9999"),
            new User(23, UserRole.User, null, null),
        };

        // repository mocking
        IUsersRepository usersRepository = Substitute.For<IUsersRepository>();
        ITransactionsRepository transactionsRepository = Substitute.For<ITransactionsRepository>();
        IAccountsRepository accountsRepository = Substitute.For<IAccountsRepository>();

        var context = new ExecutionContext(UserRole.User, new AtmUser(accounts[0], users[1]));
        var invoker = new CommandInvoker(transactionsRepository, context);
        var withdrawCommand = new WithdrawCommand(new AtmWithdrawMoney(accountsRepository), 23);
        ArgumentException exception =
            Assert.Throws<ArgumentException>(() => invoker.Consume(withdrawCommand));
        Assert.Equal("Not enough money", exception.Message);
    }

    [Fact]
    public void NotEnoughMoneyToWithdrawShouldReturnError()
    {
        IList<Account> accounts = new List<Account>
        {
            new Account(154, 3333, 21, 2),
            new Account(23, 3331, 0, 2),
        };
        IList<User> users = new List<User>
        {
            new User(1, UserRole.Admin, "admin", "9999"),
            new User(23, UserRole.User, null, null),
        };

        // repository mocking
        IUsersRepository usersRepository = Substitute.For<IUsersRepository>();
        ITransactionsRepository transactionsRepository = Substitute.For<ITransactionsRepository>();
        IAccountsRepository accountsRepository = Substitute.For<IAccountsRepository>();
        IParse parser = Substitute.For<IParse>();
        IDisplayMessage display = Substitute.For<IDisplayMessage>();
        accountsRepository.FindAccountByAccountId(154).Returns(accounts[0]);
        accountsRepository.FindUserByAccountId(154).Returns(users[1]);
        parser.GetLine().Returns(new List<string>() { "154", "3333" });

        var logger = new LogUserService(usersRepository, accountsRepository, parser, display);
        var context = new ExecutionContext(UserRole.User, new AtmUser(null, null));
        var invoker = new CommandInvoker(transactionsRepository, context);
        var logInCommand = new LogInCommand(logger, display, UserRole.User, new List<string>() { "User" });
        invoker.Consume(logInCommand);
        var withdrawCommand = new WithdrawCommand(new AtmWithdrawMoney(accountsRepository), 23);
        ArgumentException exception =
            Assert.Throws<ArgumentException>(() => invoker.Consume(withdrawCommand));
        Assert.Equal("Not enough money", exception.Message);
    }

    [Fact]
    public void EnoughMoneyToWithdrawShouldReturnCorrectAccountAmount()
    {
        IList<Account> accounts = new List<Account>
        {
            new Account(154, 3333, 21, 2),
            new Account(23, 3331, 0, 2),
        };
        IList<User> users = new List<User>
        {
            new User(1, UserRole.Admin, "admin", "9999"),
            new User(23, UserRole.User, null, null),
        };

        // repository mocking
        IUsersRepository usersRepository = Substitute.For<IUsersRepository>();
        ITransactionsRepository transactionsRepository = Substitute.For<ITransactionsRepository>();
        IAccountsRepository accountsRepository = Substitute.For<IAccountsRepository>();
        IParse parser = Substitute.For<IParse>();
        IDisplayMessage display = Substitute.For<IDisplayMessage>();
        accountsRepository.FindAccountByAccountId(154).Returns(accounts[0]);
        accountsRepository.FindUserByAccountId(154).Returns(users[1]);
        parser.GetLine().Returns(new List<string>() { "154", "3333" });

        var logger = new LogUserService(usersRepository, accountsRepository, parser, display);
        var context = new ExecutionContext(UserRole.User, new AtmUser(null, null));
        var invoker = new CommandInvoker(transactionsRepository, context);
        var logInCommand = new LogInCommand(logger, display, UserRole.User, new List<string>() { "User" });
        invoker.Consume(logInCommand);
        var withdrawCommand = new WithdrawCommand(new AtmWithdrawMoney(accountsRepository), 20);
        invoker.Consume(withdrawCommand);
        Assert.True(accounts[0].Balance == 1);
    }

    [Fact]
    public void TopUpAccountWith0ShouldReturn50()
    {
        IList<Account> accounts = new List<Account>
        {
            new Account(154, 3333, 21, 2),
            new Account(23, 3331, 0, 2),
        };
        IList<User> users = new List<User>
        {
            new User(1, UserRole.Admin, "admin", "9999"),
            new User(23, UserRole.User, null, null),
        };

        // repository mocking
        IUsersRepository usersRepository = Substitute.For<IUsersRepository>();
        ITransactionsRepository transactionsRepository = Substitute.For<ITransactionsRepository>();
        IAccountsRepository accountsRepository = Substitute.For<IAccountsRepository>();

        var context = new ExecutionContext(UserRole.User, new AtmUser(accounts[1], users[1]));
        var invoker = new CommandInvoker(transactionsRepository, context);
        var topUpCommand = new TopUpCommand(new AtmTopUp(accountsRepository), 50);
        invoker.Consume(topUpCommand);
        Assert.True(accounts[1].Balance == 50);
    }
}