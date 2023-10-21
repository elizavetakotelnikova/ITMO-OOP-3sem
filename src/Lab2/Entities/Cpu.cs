namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : IReposirotyAdded
{
    public Cpu(
        int id,
        int clockRate,
        int coresQuantity,
        string socket,
        bool hasIGpu,
        int tdp,
        int consumedPower)
    {
        Id = id;
        ClockRate = clockRate;
        CoresQuantity = coresQuantity;
        Socket = socket;
        HasIGpu = hasIGpu;
        Tdp = tdp;
        ConsumedPower = consumedPower;
    }

    public int Id { get; }
    public int ClockRate { get; }
    public int CoresQuantity { get; }
    public string Socket { get; }
    public bool HasIGpu { get; }
    public int Tdp { get; }
    public int ConsumedPower { get; }

    public void AddToRepository(Repository repository)
    {
        repository?.Cpus.Add(this);
    }
}