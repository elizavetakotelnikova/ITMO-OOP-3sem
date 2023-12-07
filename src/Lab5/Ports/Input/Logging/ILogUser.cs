using Application.Models;
using ExecutionContext = DomainLayer.Models.ExecutionContext;
namespace Ports.Input.Logging;

public interface ILogUser
{
    LogInResult LogIn(UserRole role, ExecutionContext context);
}