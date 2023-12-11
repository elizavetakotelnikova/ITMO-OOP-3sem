namespace Application.Models;

public record User
{
    public User(long id, UserRole role)
    {
        Id = id;
        Role = role;
    }

    public long Id { get; set; }
    public UserRole Role { get; set; }
}