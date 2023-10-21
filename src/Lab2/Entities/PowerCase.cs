using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerCase : IReposirotyAdded
{
    public PowerCase(int maxLoad)
    {
        MaxLoad = maxLoad;
    }

    public int MaxLoad { get; set; }

    public void AddToRepository(Repository repository)
    {
        repository?.PowerCases.Add(this);
    }
}