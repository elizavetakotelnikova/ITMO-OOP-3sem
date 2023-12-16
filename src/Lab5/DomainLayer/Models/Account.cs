namespace DomainLayer.Models;

public record Account
{
    public Account()
    {
    }

    public Account(long? id, int pinCode, int balance)
    {
        Id = id;
        PinCode = pinCode;
        Balance = balance;
    }

    public long? Id { get; set; }
    public int PinCode { get; set; }
    public int Balance { get; set; }
}