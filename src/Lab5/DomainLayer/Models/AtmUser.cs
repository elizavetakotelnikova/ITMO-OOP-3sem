using DomainLayer.ValueObjects;

namespace Application.Models;

public record AtmUser
{
    public AtmUser()
    {
    }

    public AtmUser(Account? account, UserRole role)
    {
        Account = account;
        Role = role;
    }

    public AtmUser(Account? account, UserRole role, User user)
    {
        Account = account;
        Role = role;
        User = user;
    }

    public Account? Account { get; set; }
    public User? User { get; set; }
    public UserRole Role { get; set; }
}