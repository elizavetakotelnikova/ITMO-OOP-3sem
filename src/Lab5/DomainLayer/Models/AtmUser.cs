using DomainLayer.ValueObjects;

namespace Application.Models;

public record AtmUser
{
    public AtmUser()
    {
    }

    public AtmUser(Account? account, User? user)
    {
        Account = account;
        User = user;
    }

    public Account? Account { get; set; }
    public User? User { get; set; }
}