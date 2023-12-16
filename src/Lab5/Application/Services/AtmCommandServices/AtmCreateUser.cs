using Application.Services.Builders;
using DomainLayer.Models;
using DomainLayer.ValueObjects;
using Ports.Repositories;
using ExecutionContext = DomainLayer.Models.ExecutionContext;

namespace Application.Services.ATMCommandServices;

public class AtmCreateUser : ICreateUser
{
    private readonly IUsersRepository _usersRepository;

    public AtmCreateUser(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public void CreateUser(ExecutionContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));
        if (context.CurrentMode is UserRole.User) throw new ArgumentException("Operation cannot be done. You should be an admin to do this");
        User user = new UserBuilder().WithRole(UserRole.User).Build();
        _usersRepository.Add(user);
        if (context.AtmUser is null) throw new ArgumentNullException(nameof(context));
        context.AtmUser.User = user;
    }
}