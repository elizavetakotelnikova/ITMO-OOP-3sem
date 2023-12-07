using System.Globalization;
using Application.Models;
using Application.Repositories;
using DomainLayer.ValueObjects;
using Ports.Input;
using Ports.Input.Logging;
using Ports.Output;
using ExecutionContext = DomainLayer.Models.ExecutionContext;

namespace Adapters.Persistence;

internal class LogUserService : ILogUser
{
    private readonly IUsersRepository _userRepository;
    private readonly IAccountsRepository _accountsRepository;
    private AtmUser? _currentUser; // пока непонятно зачем здесь делать интефрейс
    private IParse _parser;
    private IDisplayMessage _outputDisplayer;

    public LogUserService(IUsersRepository userRepository, IAccountsRepository accountsRepository, AtmUser currentAccount, IParse parse, IDisplayMessage outputDisplayer)
    {
        _userRepository = userRepository;
        _accountsRepository = accountsRepository;
        _currentUser = currentAccount;
        _parser = parse;
        _outputDisplayer = outputDisplayer;
    }

    public SearchResult LogInUser(ExecutionContext context)
    {
        _outputDisplayer.DisplayMessage("ENTER ACCOUNT ID AND PIN CODE IN THE NEXT LINE");
        IList<string> tokenizedLine = _parser.GetLine();
        Account? account = _accountsRepository.FindAccountByNumber(long.Parse(tokenizedLine[0], new NumberFormatInfo()));

        if (account is null)
        {
            return SearchResult.NotFound;
        }

        if (account.AccountPinCode != long.Parse(tokenizedLine[1], new NumberFormatInfo())) return SearchResult.NotFound;
        _currentUser = new AtmUser(account, UserRole.User); // или это в контекст закинуть
        context.AtmUser = _currentUser; // или тут не статика должна быть
        return SearchResult.Success;
    }

    public SearchResult LogInAdmin(ExecutionContext context)
    {
        _outputDisplayer.DisplayMessage("ENTER ADMIN'S PASSWORD");
        IList<string> tokenizedLine = _parser.GetLine();
        DataCheckResult check = CheckPassword("admin", tokenizedLine[0]);
        if (check is DataCheckResult.Incorrect)
        {
            return SearchResult.NotFound;
        }

        _currentUser = new AtmUser(null, UserRole.Admin); // или это в контекст закинуть
        context.AtmUser = _currentUser; // или тут не статика должна быть
        return SearchResult.Success;
    }

    public DataCheckResult CheckPassword(string username, string providedPassword)
    {
        string? actualPassword = _userRepository.FindPasswordByUsername(username);

        if (actualPassword is null) return DataCheckResult.Incorrect;
        if (!providedPassword.Equals(actualPassword, StringComparison.Ordinal)) return DataCheckResult.Incorrect;
        return DataCheckResult.Correct;
    }

    public LogInResult LogIn(UserRole role, ExecutionContext context)
    {
        SearchResult result = SearchResult.Success;
        if (role == UserRole.User) result = LogInUser(context);
        if (role == UserRole.Admin) result = LogInAdmin(context);
        if (result == SearchResult.NotFound) return LogInResult.NotFound;
        return LogInResult.Success;
    }
}