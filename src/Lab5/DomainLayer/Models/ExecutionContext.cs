using Application.Models;

namespace DomainLayer.Models;

public class ExecutionContext
{
    public ExecutionContext(UserRole mode, AtmUser user)
    {
        CurrentMode = mode;
        AtmUser = user;
    }

    public UserRole CurrentMode { get; set; }
    public AtmUser AtmUser { get; set; }
}