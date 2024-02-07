using DomainLayer.ValueObjects;

namespace Ports.Input.Logging;

public interface IAuthorizeUser : ILogUser
{
    DataCheckResult CheckPassword(string username, string providedPassword);
}