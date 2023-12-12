// using Application.Models;

using Application.Models;

namespace Application.Repositories;

public interface IUsersRepository
{
    // User? FindUserByUsername(string username);
    string? FindPasswordByUsername(string username);
    bool ExistsId(long? id);
    void Add(User user);
}