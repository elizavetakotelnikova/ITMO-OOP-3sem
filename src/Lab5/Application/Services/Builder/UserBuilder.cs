using Application.Models;

namespace Application.Services.Builder;

public class UserBuilder
{
    private long _id;
    private string? _name;
    private string? _password;
    private UserRole _role;

    public UserBuilder()
    {
    }

    public UserBuilder(User user)
    {
        if (user is null) throw new ArgumentNullException(nameof(user));
        _id = user.Id;
        _name = user.Name;
        _role = user.Role;
        _password = user.Password;
    }

    public UserBuilder WithRole(UserRole role)
    {
        _role = role;
        return this;
    }

    public UserBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public UserBuilder WithPassword(string password)
    {
        _password = password;
        return this;
    }

    public UserBuilder WithId(long id)
    {
        _id = id;
        return this;
    }

    public User Build()
    {
        return new User(_id, _role, _name, _password);
    }
}