using DomainLayer.ValueObjects;
using ExecutionContext = DomainLayer.Models.ExecutionContext;

namespace Application.Services.ATMCommandServices;

public class AtmDisconnect : IDisconnect
{
    public void Disconnect(ExecutionContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));
        context.AtmUser.User = null;
        context.AtmUser.Account = null;
        context.CurrentMode = UserRole.User;
    }
}