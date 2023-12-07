// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
namespace Lab5;

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
    .AddPresentationConsole();

var provider = collection.BuildServiceProvider();
var scope = provider.CreateScope();
scope.UseInfrastructureDataAccess();