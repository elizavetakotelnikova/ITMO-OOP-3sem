namespace Application.Models;

public record User
{
    public User(long id, string? userName, UserRole role)
    {
        Id = id;
        UserName = userName;
        Role = role;
    }

    public long Id { get; set; }
    public string? UserName { get; set; }
    public UserRole Role { get; set; }
}