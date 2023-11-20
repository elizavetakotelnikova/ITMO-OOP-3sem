using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4;

internal class Program
{
    public static void Main()
    {
        // configure
        var treeListParams = new TreeListCommandParameters((char)120, (char)66, '-');
        var localFileSystem = new Filesystem();
        ListOfCommands.ReturnInstance(treeListParams, localFileSystem);
        var parser = new ConsoleCommandParser();
        var appContext = new ExecutionContext(null);
        var invoker = new CommandInvoker(appContext);

        // commands parsing
        while (true)
        {
            try
            {
                ICommand command = parser.Parse();
                invoker.Consume(command);
                if (command is DisconnectCommand) break;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                break;
            }
        }
    }
}