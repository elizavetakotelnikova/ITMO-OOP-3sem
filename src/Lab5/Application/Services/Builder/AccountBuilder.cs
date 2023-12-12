using DomainLayer.ValueObjects;

namespace Application.Services.Builder;

public class AccountBuilder
{
    private long? _id;
    private int _pinCode;
    private int _amount;

    public AccountBuilder()
    {
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