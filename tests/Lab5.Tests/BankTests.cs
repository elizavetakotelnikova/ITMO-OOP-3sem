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

    /*[Fact]
    public void ConnectAndTreeGoToPassedShouldReturnRightPath()
    {
        Console.SetIn(new StringReader(
            "connect C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem -m local"));
        var parser = new ConsoleCommandParser();
        ICommand result = parser.Parse();
        var invoker = new CommandInvoker(new ExecutionContext(null));
        invoker.Consume(result);
        Assert.True(result is ConnectCommand);
        Assert.Equal("C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem", invoker.Context.CurrentPath);

        Console.SetIn(new StringReader("tree goto \\Testing"));
        result = parser.Parse();
        invoker.Consume(result);
        Assert.True(result is GoToCommand);
        Assert.Equal("C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem\\Testing", invoker.Context.CurrentPath);

        Console.SetIn(new StringReader("disconnect"));
        result = parser.Parse();

        invoker.Consume(result);
        Assert.True(result is DisconnectCommand);
        Assert.Null(invoker.Context.CurrentPath);
    }

    [Fact]
    public void ConnectAndTreeListPassedShouldReturnPrintedOnce()
    {
        Console.SetIn(new StringReader("connect C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem -m local"));
        var parser = new ConsoleCommandParser();
        ICommand result = parser.Parse();
        var invoker = new CommandInvoker(new ExecutionContext(null));
        invoker.Consume(result);

        Console.SetIn(new StringReader("tree list -d 2"));
        result = parser.Parse();
        invoker.Consume(result);
        Assert.True(result is TreeListCommand);
        var newResult = new Mock<ICommand>();
        invoker.Consume(newResult.Object);
        newResult.Verify(x => x.Execute(invoker.Context), Times.Once);
    }

    /*[Fact]
    public void ConnectAndFileRenameCommandsPassedShouldRenameFile()
    {
        Console.SetIn(new StringReader(
            "connect C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem -m local"));
        var parser = new ConsoleCommandParser();
        ICommand result = parser.Parse();
        var invoker = new CommandInvoker(new ExecutionContext(null));
        invoker.Consume(result);
        Assert.True(result is ConnectCommand);
        Assert.Equal("C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem", invoker.Context.CurrentPath);
        Console.SetIn(new StringReader("file rename \\text.txt NewNaming.txt"));
        result = parser.Parse();
        string filePath =
            "C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem\\text.txt";
        var fileInfo = new FileInfo(filePath);
        using (File.Create(filePath))
        {
        }

        invoker.Consume(result);
        Assert.True(result is FileRenameCommand);
        Assert.Equal("C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem", invoker.Context.CurrentPath);
        Assert.True(System.IO.File.Exists(
            @"C:\Users\Ryzen\Desktop\university\OOP\elizavetakotelnikova\src\Lab4\Filesystem\\NewNaming.txt"));
        fileInfo.Delete();
        File.Delete(@"C:\Users\Ryzen\Desktop\university\OOP\elizavetakotelnikova\src\Lab4\Filesystem\\NewNaming.txt");
    }

    [Fact]
    public void ConnectAndFileCopyCommandsPassedShouldCopyFile()
    {
        Console.SetIn(new StringReader("connect C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem -m local"));
        var parser = new ConsoleCommandParser();
        ICommand result = parser.Parse();
        var invoker = new CommandInvoker(new ExecutionContext(null));
        invoker.Consume(result);
        Assert.True(result is ConnectCommand);
        Assert.Equal("C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem", invoker.Context.CurrentPath);

        Console.SetIn(new StringReader("connect \\Testing -m local"));
        result = parser.Parse();
        invoker.Consume(result);
        Assert.True(result is ConnectCommand);
        Assert.Equal("C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem\\Testing", invoker.Context.CurrentPath);

        Console.SetIn(new StringReader("file copy \\forCopy.txt \\TestingLevel2"));
        result = parser.Parse();

        invoker.Consume(result);
        Assert.True(result is FileCopyCommand);
        Assert.Equal("C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem\\Testing", invoker.Context.CurrentPath);
        Assert.True(System.IO.File.Exists(@"C:\Users\Ryzen\Desktop\university\OOP\elizavetakotelnikova\src\Lab4\Filesystem\Testing\forCopy.txt"));
        File.Delete(@"C:\Users\Ryzen\Desktop\university\OOP\elizavetakotelnikova\src\Lab4\Filesystem\Testing\TestingLevel2\forCopy.txt");
    }

    [Fact]
    public void ConnectAndFileDeletePassedShouldReturnDeleted()
    {
        Console.SetIn(new StringReader("connect C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem -m local"));
        var parser = new ConsoleCommandParser();
        ICommand result = parser.Parse();
        var invoker = new CommandInvoker(new ExecutionContext(null));
        invoker.Consume(result);
        Assert.True(result is ConnectCommand);
        Assert.Equal("C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem", invoker.Context.CurrentPath);
        Console.SetIn(new StringReader("file delete \\toDelete.txt"));
        result = parser.Parse();
        string filePath = "C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem\\toDelete.txt";
        var fileInfo = new FileInfo(filePath);
        using (File.Create(filePath))
        {
        }

        Assert.True(System.IO.File.Exists(@"C:\Users\Ryzen\Desktop\university\OOP\elizavetakotelnikova\src\Lab4\Filesystem\toDelete.txt"));
        invoker.Consume(result);
        Assert.True(result is FileDeleteCommand);
        Assert.Equal("C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem", invoker.Context.CurrentPath);
        Assert.False(System.IO.File.Exists(@"C:\Users\Ryzen\Desktop\university\OOP\elizavetakotelnikova\src\Lab4\Filesystem\toDelete.txt"));
        fileInfo.Delete();
    }

    [Fact]
    public void ConnectAndFileMoveCommandPassedShouldMoveFile()
    {
        Console.SetIn(new StringReader("connect C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem -m local"));
        var parser = new ConsoleCommandParser();
        ICommand result = parser.Parse();
        var invoker = new CommandInvoker(new ExecutionContext(null));
        invoker.Consume(result);
        Assert.True(result is ConnectCommand);
        Assert.Equal("C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem", invoker.Context.CurrentPath);
        Console.SetIn(new StringReader("file move \\text.txt \\Testing\\TestingLevel2"));
        result = parser.Parse();
        string filePath = "C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem\\text.txt";
        var fileInfo = new FileInfo(filePath);
        using (File.Create(filePath))
        {
        }

        invoker.Consume(result);
        Assert.True(result is FileMoveCommand);
        Assert.Equal("C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem", invoker.Context.CurrentPath);
        Assert.True(System.IO.File.Exists(@"C:\Users\Ryzen\Desktop\university\OOP\elizavetakotelnikova\src\Lab4\Filesystem\\Testing\\TestingLevel2\\text.txt"));
        fileInfo.Delete();
        File.Delete(@"C:\Users\Ryzen\Desktop\university\OOP\elizavetakotelnikova\src\Lab4\Filesystem\\Testing\\TestingLevel2\\text.txt");
    }*/
}