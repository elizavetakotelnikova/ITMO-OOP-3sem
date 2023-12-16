using DomainLayer.Models;

namespace Application.Services.Builders;

public class AccountBuilder
{
    private long? _id;
    private int _pinCode;
    private int _amount;
    private long? _userId;

    public AccountBuilder()
    {
    }

    public AccountBuilder(Account account)
    {
        if (account is null) throw new ArgumentNullException(nameof(account));
        _id = account.Id;
        _pinCode = account.PinCode;
        _amount = account.Balance;
        _userId = account.UserId;
    }

    public AccountBuilder WithAmount(int amount)
    {
        _amount = amount;
        return this;
    }

    public AccountBuilder WithPinCode(int pinCode)
    {
        _pinCode = pinCode;
        return this;
    }

    public AccountBuilder WithId(long id)
    {
        _id = id;
        return this;
    }

    public AccountBuilder WithUserId(long userId)
    {
        _userId = userId;
        return this;
    }

    public Account Build()
    {
        if (_userId is null) throw new ArgumentException("userId is not specified");
        return new Account(_id, _pinCode, _amount, _userId);
    }
}