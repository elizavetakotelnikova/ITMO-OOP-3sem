using System;
namespace Itmo.ObjectOrientedProgramming.Lab4;

internal class Program
{
    public static void Main()
    {
        Parserhandler commandsParser = new ConsoleCommandsParser();
        while (commandsParser.Parse())
        {

            Parser.Default
                .ParseArguments<CliCommands>(args)
                .WithParsed(RunProgram)
                .WithNotParsed(x => new LocalState().ListCommands());
        }
    }

    private static void RunProgram(CliCommands options)
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
    }
}