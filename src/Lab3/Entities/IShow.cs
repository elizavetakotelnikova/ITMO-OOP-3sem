using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public interface IShow
{
    public void DisplayMessage();
    public void DisplayColorMessage(Colors color);
}