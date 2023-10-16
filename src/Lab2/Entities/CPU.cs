namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : IReposirotyAdded
{
    public Cpu(
        int clockRate,
        int coresQuantity,
        int socket,
        bool hasIGpu,
        int tdp,
        int consumedPower)
    {
        ClockRate = clockRate;
        CoresQuantity = coresQuantity;
        Socket = socket;
        HasIGpu = hasIGpu;
        Tdp = tdp;
        ConsumedPower = consumedPower;
    }

    public int ClockRate { get; set; }
    public int CoresQuantity { get; set; }
    public int Socket { get; set; }
    public bool HasIGpu { get; set; }
    public int Tdp { get; set; }
    public int ConsumedPower { get; set; }

    public void AddToRepository(Repository repository)
    {
        repository?.Cpus.Add(this);
    }
}