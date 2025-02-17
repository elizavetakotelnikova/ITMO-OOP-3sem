using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTests
{
    // tests with files and directories are commented because of the github check
    [Fact]
    public void ConnectAndDisconnectCommandPassedShouldReturnPathes()
    {
        Console.SetIn(new StringReader("connect C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem -m local"));
        var parser = new ConsoleCommandParser();
        ICommand result = parser.Parse();
        var invoker = new CommandInvoker(new ExecutionContext(null));
        invoker.Consume(result);
        Assert.True(result is ConnectCommand);
        Assert.Equal("C:\\Users\\Ryzen\\Desktop\\university\\OOP\\elizavetakotelnikova\\src\\Lab4\\Filesystem", invoker.Context.CurrentPath);
        Console.SetIn(new StringReader("disconnect"));
        result = parser.Parse();
        invoker.Consume(result);
        Assert.True(result is DisconnectCommand);
        Assert.Null(invoker.Context.CurrentPath);
    }

    [Fact]
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