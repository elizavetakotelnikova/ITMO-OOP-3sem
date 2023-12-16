using DomainLayer.Models;

namespace Application.Services.Builders;

public class AccountBuilder
{
    private long? _id;
    private int _pinCode;
    private int _amount;

    public AccountBuilder()
    {
    }

    public AccountBuilder(Account account)
    {
        if (account is null) throw new ArgumentNullException(nameof(account));
        _id = account.Id;
        _pinCode = account.PinCode;
        _amount = account.Balance;
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

    public Account Build()
    {
        return new Account(_id, _pinCode, _amount);
    }
}