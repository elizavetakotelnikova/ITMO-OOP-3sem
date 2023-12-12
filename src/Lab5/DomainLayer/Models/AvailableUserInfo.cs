using Application.Models;

namespace DomainLayer.Models;

public class AvailableUserInfo
{
    public AvailableUserInfo(long? id, UserRole? role, string? name, string? password)
    {
        Id = id;
        Role = role;
        Name = name;
        Password = password;
    }

    public long? Id { get; set; }
    public UserRole? Role { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
}