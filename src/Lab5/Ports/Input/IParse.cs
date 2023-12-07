using Application.Models;

namespace Ports.Input;

public interface IParse
{
    public IList<string> GetLine();
    public ICommand Parse();
}