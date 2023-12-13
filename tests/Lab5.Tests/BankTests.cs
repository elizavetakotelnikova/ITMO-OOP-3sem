using System;
using System.IO;
using Adapters;
using Adapters.UI;
using Application.Commands;
using Application.Models;
using Application.ServiceCollectionExtensions;
using Application.Services;
using Application.Services.Builder;
using DomainLayer.Models;
using DomainLayer.ValueObjects;
using Microsoft.Extensions.DependencyInjection;
using Ports.Repositories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankTests
{
    // tests with files and directories are commented because of the github check
    [Fact]
    public void NotEnoughMoneyToWithdrawShouldReturnError()
    {
        var collection = new ServiceCollection();

        collection
            .AddApplication()
            .AddInfrastructureDataAccess(configuration =>
            {
                configuration.Host = "localhost";
                configuration.Port = 6432;
                configuration.Username = "postgres";
                configuration.Password = "postgres";
                configuration.Database = "postgres";
                configuration.SslMode = "Prefer";
            })
            .AddAdapters();

        ServiceProvider provider = collection.BuildServiceProvider();
        var configure = new Configure(provider);

        // repository mocking
        IUsersRepository usersRepository = NSubstitute.Substitute.For<IUsersRepository>();
        ITransactionsRepository transactionsRepository = NSubstitute.Substitute.For<ITransactionsRepository>();
        IAccountsRepository accountsRepository = NSubstitute.Substitute.For<IAccountsRepository>();

        // creating test entities
        User testUser = new UserBuilder().WithRole(UserRole.User).WithName("Sam").Build();
        Account testAccount = new AccountBuilder().WithPinCode(5643).Build();
        usersRepository.Add(testUser);
        accountsRepository.Add(testAccount, testUser);
        testUser = new UserBuilder(testUser).WithId(1).Build();
        testAccount = new AccountBuilder(testAccount).WithId(200).WithAmount(2).WithPinCode(5643).Build();

        // testing itself
        Console.SetIn(new StringReader("log in User"));
        var parser = new ConsoleCommandParser();
        ICommand result = parser.Parse();
        var invoker = new CommandInvoker(transactionsRepository, new ExecutionContext(UserRole.User, new AtmUser(testAccount, testUser)));
        Console.SetIn(new StringReader($"1 1234"));
        invoker.Consume(result);
        Console.SetIn(new StringReader("withdraw 23"));
        result = parser.Parse();
        ArgumentException exception =
            Assert.Throws<ArgumentException>(() => invoker.Consume(result));
        Assert.Equal("Not enough money", exception.Message);
    }

    /*[Fact]
    public void FileRenameCommandWithoutConnectShouldReturnArgumentNullException()
    {
        var parser = new ConsoleCommandParser();
        var invoker = new CommandInvoker(new ExecutionContext(null));
        Console.SetIn(new StringReader("file rename \\text.txt NewNaming.txt"));
        ICommand result = parser.Parse();
        ArgumentNullException exception =
            Assert.Throws<ArgumentNullException>(() => invoker.Consume(result));
    }

    [Fact]
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