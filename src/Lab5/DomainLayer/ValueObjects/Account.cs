namespace DomainLayer.ValueObjects;

public record Account
{
    /*public Account(long accountId, int pinCode)
    {
        AccountId = accountId;
        AccountPinCode = pinCode;
    }*/

    public Account(long accountId, int accountPinCode, int amount)
    {
        AccountId = accountId;
        AccountPinCode = accountPinCode;
        Amount = amount;
    }

    public long AccountId { get; set; }
    public int AccountPinCode { get; set; }
    public int Amount { get; set; }
}