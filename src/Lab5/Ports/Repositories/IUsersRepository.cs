using DomainLayer.Models;

namespace Ports.Repositories;

public interface IUsersRepository
{
    User? FindUserByUsername(string username);
    string? FindPasswordByUsername(string username);
    bool ExistsId(long? id);
    bool ExistsUsername(string username);
    void Add(User user);
    void Delete(User user);
}