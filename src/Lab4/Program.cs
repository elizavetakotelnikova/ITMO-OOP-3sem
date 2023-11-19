using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4;

internal class Program
{
    public static void Main()
    {
        var parser = new ConsoleCommandParser();
        var appContext = new ExecutionContext(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")));
        var invoker = new CommandInvoker(appContext);
        while (true)
        {
            try
            {
                invoker.Consume(parser.Parse());
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                break;
            }
        }
    }
}