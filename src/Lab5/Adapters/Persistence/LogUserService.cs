using System.Globalization;
using DomainLayer.Models;
using DomainLayer.ValueObjects;
using Ports.Input;
using Ports.Input.Logging;
using Ports.Output;
using Ports.Repositories;
using ExecutionContext = DomainLayer.Models.ExecutionContext;

namespace Adapters.Persistence;

public class LogUserService : IAuthorizeUser
{
    private readonly IUsersRepository _userRepository;
    private readonly IAccountsRepository _accountsRepository;
    private IParse _parser;
    private IDisplayMessage _outputDisplayer;

    public LogUserService(IUsersRepository userRepository, IAccountsRepository accountsRepository, IParse parse, IDisplayMessage outputDisplayer)
    {
        _userRepository = userRepository;
        _accountsRepository = accountsRepository;
        _parser = parse;
        _outputDisplayer = outputDisplayer;
    }

    public SearchResult LogInUser(ExecutionContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));
        _outputDisplayer.DisplayMessage("Enter account ID and PIN code in the next line");
        IList<string> tokenizedLine = _parser.GetLine();
        Account? account = _accountsRepository.FindAccountByAccountId(int.Parse(tokenizedLine[0], new NumberFormatInfo()));
        if (account is null)
        {
            return SearchResult.NotFound;
        }

        if (account.PinCode != int.Parse(tokenizedLine[1], new NumberFormatInfo())) return SearchResult.NotFound;
        User? user = _accountsRepository.FindUserByAccountId(account.Id);
        context.CurrentMode = UserRole.User;
        context.AtmUser = new AtmUser(account, user);
        return SearchResult.Success;
    }

    public SearchResult LogInAdmin(ExecutionContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));
        _outputDisplayer.DisplayMessage("Enter admin's password");
        IList<string> tokenizedLine = _parser.GetLine();
        DataCheckResult check = CheckPassword("admin", tokenizedLine[0]);
        if (check is DataCheckResult.Incorrect)
        {
            return SearchResult.NotFound;
        }

        User? user = _userRepository.FindUserByUsername("admin");
        context.AtmUser = new AtmUser(null, user);
        context.CurrentMode = UserRole.Admin;
        return SearchResult.Success;
    }

    public DataCheckResult CheckPassword(string username, string providedPassword)
    {
        string? actualPassword = _userRepository.FindPasswordByUsername(username);

        if (actualPassword is null) return DataCheckResult.Incorrect;
        if (!actualPassword.Equals(providedPassword, StringComparison.Ordinal)) return DataCheckResult.Incorrect;
        return DataCheckResult.Correct;
    }

    public LogInResult LogIn(UserRole role, ExecutionContext context)
    {
        SearchResult result = SearchResult.Success;
        switch (role)
        {
            case UserRole.Admin:
                result = LogInAdmin(context);
                break;
            case UserRole.User:
                result = LogInUser(context);
                break;
        }

        if (result == SearchResult.NotFound) return LogInResult.NotFound;
        return LogInResult.Success;
    }
}