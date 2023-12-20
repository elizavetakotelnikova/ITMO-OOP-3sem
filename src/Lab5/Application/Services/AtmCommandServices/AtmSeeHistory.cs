using DomainLayer.Models;
using Ports.Output;
using Ports.Repositories;
using ExecutionContext = DomainLayer.Models.ExecutionContext;

namespace Application.Services.ATMCommandServices;

public class AtmSeeHistory : ISeeHistory
{
    private readonly ITransactionsRepository _repository;
    private readonly IDisplayMessage _display;

    public AtmSeeHistory(ITransactionsRepository repository, IDisplayMessage display)
    {
        _repository = repository;
        _display = display;
    }

    public void SeeHistory(ExecutionContext context)
    {
        IList<Transaction>? requestedHistory = _repository.GetTransactionsByUserId(context);
        if (requestedHistory is null || requestedHistory.Count == 0)
        {
            _display.DisplayMessage("No operations yet");
            return;
        }

        requestedHistory.ToList().ForEach(x => _display.DisplayMessage($"Account {x.AccountId}, type {x.Type}, state {x.State}"));
    }
}