using DomainLayer.ValueObjects;

namespace Application.Models;

public record AtmUser
{
    public AtmUser(Account? account, UserRole role)
    {
        Account = account;
        Role = role;
    }

    public Account? Account { get; set; }
    public UserRole Role { get; set; }
}