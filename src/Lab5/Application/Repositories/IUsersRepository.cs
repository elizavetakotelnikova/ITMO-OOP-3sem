// using Application.Models;

namespace Application.Repositories;

public interface IUsersRepository
{
    // User? FindUserByUsername(string username);
    string? FindPasswordByUsername(string username);
}