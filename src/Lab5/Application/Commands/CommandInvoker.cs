using DomainLayer.Entities;
using DomainLayer.Models;
using Ports.Repositories;
using ExecutionContext = DomainLayer.Models.ExecutionContext;

namespace Application.Commands;

public class CommandInvoker : ICommandInvoker
{
    private readonly ITransactionsRepository _history;
    private readonly ExecutionContext _context;

    public CommandInvoker(ITransactionsRepository? history, ExecutionContext context)
    {
        _history = history ?? throw new ArgumentNullException(nameof(history));
        _context = context;
    }

    public void Consume(ICommand command)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));
        command.Execute(_context);
        _history.Add(_context, command);
    }
}