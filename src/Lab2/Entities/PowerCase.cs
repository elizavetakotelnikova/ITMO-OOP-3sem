namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class PowerCase
{
    public PowerCase(int maxLoad)
    {
        MaxLoad = maxLoad;
    }

    public int MaxLoad { get; set; }
}