namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerCase
{
    public PowerCase(int maxLoad)
    {
        MaxLoad = maxLoad;
    }

    public int MaxLoad { get; }
}