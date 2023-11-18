using System;
using System.IO;
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

            invoker.Consume(parser.Parse());
        }
    }

    /*private static void RunProgram(CliCommands options)
    {
        var cfgChain = Chain.CreateChain<string, IApplicationState>
        (
            builder => builder
                .Then<ProductionLink>()
                .Then<DevelopmentLink>()
                .FinishWith(() => new UnknownState())
        );

        var applicationState = cfgChain.Process(options.Environment);
        if (applicationState.CurrentEnvironment is Environment.Unknown)
        {
            throw new Exception("User must specify environment");
        }

        Console.WriteLine($"Application context is {applicationState.CurrentEnvironment}");
        if (options.ShouldSayHello)
        {
            applicationState.SayHello();
        }

        if (options.WantHelp)
        {
            applicationState.ListCommands();
        }
    }*/
}