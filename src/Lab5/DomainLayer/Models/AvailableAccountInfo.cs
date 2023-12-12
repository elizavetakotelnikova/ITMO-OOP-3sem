namespace DomainLayer.Models;

public class AvailableAccountInfo
{
    public AvailableAccountInfo(long? accountId, int? accountPinCode, int? amount, long? userId)
    {
        AccountId = accountId;
        AccountPinCode = accountPinCode;
        Amount = amount;
        UserId = userId;
    }

    public long? AccountId { get; set; }
    public int? AccountPinCode { get; set; }
    public int? Amount { get; set; }
    public long? UserId { get; set; }
}